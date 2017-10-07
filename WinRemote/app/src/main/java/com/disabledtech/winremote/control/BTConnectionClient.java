package com.disabledtech.winremote.control;

import android.bluetooth.BluetoothAdapter;
import android.bluetooth.BluetoothDevice;
import android.bluetooth.BluetoothSocket;
import android.content.BroadcastReceiver;
import android.content.Context;
import android.content.Intent;
import android.os.ParcelUuid;

import com.disabledtech.winremote.exceptions.BluetoothInitializationException;
import com.disabledtech.winremote.interfaces.IServerConnectionListener;
import com.disabledtech.winremote.utils.Debug;

import java.io.IOException;
import java.util.HashSet;
import java.util.Set;
import java.util.UUID;

import static com.disabledtech.winremote.interfaces.IServerConnectionListener.SERVER_ERROR_CODE.*;

/**
 * Provides a convenience class to connectToServer to a bluetooth server.
 * This class explicitly connects to a pre-processed UUID, using the
 * RFCOMM protocol and a SDP lookup of said UUID.
 */
public class BTConnectionClient extends BroadcastReceiver {

    private final String SERVER_ID = "2BBF4D1B-9A19-4709-9399-B6AB4A88E777";
    private final UUID SERVER_UUID = UUID.fromString(SERVER_ID);

    private BluetoothAdapter bluetoothAdapter;
    private IServerConnectionListener connectionCallbackListener;
    private boolean serverFound;

    /**
     * Initializes the bluetooth adapter and enables it
     * if it is not already enabled.
     *
     * @throws BluetoothInitializationException If the adapter cannot be initialized. This could
     * be from the device not supporting bluetooth, or from an error when enabling. See
     *
     */
    public BTConnectionClient(IServerConnectionListener listener) {

        connectionCallbackListener = listener;
        serverFound = false;

        if(initializeBluetooth() == false)
        {
            Debug.logError("Bluetooth initialization failed!");
            listener.notifyCriticalFailure(BLUETOOTH_NOT_AVAILABLE);
        };
    }

    /**
     * Initializes the bluetooth adapter and ensures that
     * it is enabled and ready for connections.
     *
     * @return True if the bluetooth adapter
     */
    private boolean initializeBluetooth() {

        // FIXME: this might require different configs for < JELLY_BEAN_MR2, but the docs are contradictory. Revisit w/ emulator
        bluetoothAdapter = BluetoothAdapter.getDefaultAdapter();

        if(bluetoothAdapter == null)
        {
            return false;
        }

        return bluetoothAdapter.isEnabled() || bluetoothAdapter.enable();
    }

    /**
     * Connects to the server by first searching in already bonded devices,
     * and then searching the area for devices. When the server is
     * located, then the connection socket will be returned in the
     * {@link IServerConnectionListener} callback. If the server
     * connection cannot be established, the reasons will be logged.
     *
     */
    public void connectToServer() {

        if (bluetoothAdapter.isDiscovering()) {

            bluetoothAdapter.cancelDiscovery();
        }

        BluetoothDevice server = searchForServer(bluetoothAdapter.getBondedDevices());

        if(server == null)
        {
            // Notifications and logic continued in onReceive
            bluetoothAdapter.startDiscovery();
            return;
        }

        connectToServerAndNotify(server);
    }

    /**
     * Called when the bluetooth discovery has found a device
     * or when the discovery has been completed.
     *
     * @param context
     * @param intent
     */
    @Override
    public void onReceive(Context context, Intent intent) {

        final String ACTION = intent.getAction();

        switch (ACTION) {

            case BluetoothDevice.ACTION_FOUND:

                BluetoothDevice server = findServerFromIntent(intent);

                if(server == null)
                {
                    return;
                }
                else
                {
                    connectToServerAndNotify(server);
                }

                break;

            case BluetoothAdapter.ACTION_DISCOVERY_STARTED:

                Debug.log("Discovery started");
                break;

            case BluetoothAdapter.ACTION_DISCOVERY_FINISHED:

                Debug.log("Discovery ended");
                if(serverFound == false)
                {
                    connectionCallbackListener.notifyRecoverableFailure(SERVER_NOT_FOUND);
                }
                break;
        }
    }

    /**
     * Takes the given intent and determines if it is the server or not.
     *
     * @param intent
     * @return A BluetoothDevice representing the server, or null.
     */
    private BluetoothDevice findServerFromIntent(Intent intent) {

        BluetoothDevice deviceFound = intent.getParcelableExtra(BluetoothDevice.EXTRA_DEVICE);

        if(deviceFound == null)
        {
            return null;
        }

        Debug.log("Found: " + deviceFound.getName() + " in discovery.");

        return searchForServer(deviceFound);
    }

    /**
     * Takes the given BluetoothDevice and attempts to open a connection
     * with the server. If a connection is established, this method will
     * notify the IServerConnectionListener listener. Otherwise, an
     * error will be logged.
     *
     * @param server
     */
    private void connectToServerAndNotify(BluetoothDevice server) {

        try
        {
            BluetoothSocket socketConnection = server.createInsecureRfcommSocketToServiceRecord(SERVER_UUID); // TODO secure
            connectionCallbackListener.serverConnected(socketConnection);
            serverFound = true;
            bluetoothAdapter.cancelDiscovery();

        } catch (IOException e) {

            Debug.logError("Could not open server connection!");
            e.printStackTrace();
            connectionCallbackListener.notifyRecoverableFailure(SOCKET_CONNECTION_FAILED);
        }

    }

    /**
     * See {@link #searchForServer(Set)} }
     */
    private BluetoothDevice searchForServer(BluetoothDevice device) {

        Set<BluetoothDevice> deviceList = new HashSet<>();
        deviceList.add(device);

        return searchForServer(deviceList);
    }

    /**
     * Queries the devices for the server.
     * If the server is found, the BluetoothDevice will be
     * returned. If the server cannot be found, this method will return null.
     *
     * @return The BluetoothDevice representing the server if found, or null.
     */
    private BluetoothDevice searchForServer(Set<BluetoothDevice> devices) {

        for(BluetoothDevice device : devices)
        {
            device.fetchUuidsWithSdp();

            if(serverUUIDContained(device.getUuids()))
            {
                return bluetoothAdapter.getRemoteDevice(device.getAddress());
            }
        }

        return null;
    }

    /**
     * Checks the list of UUID's for the server.
     * @param uuidList
     * @return True if found, false otherwise.
     */
    private boolean serverUUIDContained(ParcelUuid[] uuidList) {

        for(int i = 0; i < uuidList.length; i++)
        {
            String UUID = uuidList[i].getUuid().toString();
            Debug.log("Found UUID " + uuidList[i].getUuid().toString());

            if(UUID.equalsIgnoreCase(SERVER_ID))
            {
                Debug.log("Found server.");
                return true;
            }
        }

        return false;
    }

}
