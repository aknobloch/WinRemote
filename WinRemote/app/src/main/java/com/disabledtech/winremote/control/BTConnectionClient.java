package com.disabledtech.winremote.control;

import android.bluetooth.BluetoothAdapter;
import android.bluetooth.BluetoothDevice;
import android.bluetooth.BluetoothSocket;
import android.content.BroadcastReceiver;
import android.content.Context;
import android.content.Intent;
import android.content.IntentFilter;
import android.os.Parcelable;

import com.disabledtech.winremote.interfaces.IServerConnectionListener;
import com.disabledtech.winremote.utils.Debug;

import java.io.IOException;
import java.util.ArrayList;
import java.util.List;
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

    private BluetoothAdapter m_BluetoothAdapter;
    private IServerConnectionListener m_ConnectionCallbackListener;
    private List<BluetoothDevice> m_NearbyDevices;
    private boolean m_ActivelySearching;

    public BTConnectionClient(){};

    /**
     * Initializes the bluetooth adapter and enables it
     * if it is not already enabled. Will notify the callback
     * if an initialization error occurs.
     *
     */
    public BTConnectionClient(Context context, IServerConnectionListener listener) {

        m_ConnectionCallbackListener = listener;
        m_ActivelySearching = false;

        registerBroadcastEvents(context);

        if(initializeBluetooth() == false)
        {
            Debug.logError("Bluetooth initialization failed!");
            listener.notifyCriticalFailure(BLUETOOTH_NOT_AVAILABLE);
        }
    }

    /**
     * Registers this broadcast receiver to receive
     * the relevant events for the state of bluetooth.
     *
     * @param context
     */
    private void registerBroadcastEvents(Context context) {

        IntentFilter broadcastEventFilter = new IntentFilter();
        broadcastEventFilter.addAction(BluetoothAdapter.ACTION_DISCOVERY_STARTED);
        broadcastEventFilter.addAction(BluetoothAdapter.ACTION_DISCOVERY_FINISHED);
        broadcastEventFilter.addAction(BluetoothDevice.ACTION_FOUND);
        broadcastEventFilter.addAction(BluetoothDevice.ACTION_UUID);

        context.registerReceiver(this, broadcastEventFilter);
    }

    /**
     * Initializes the bluetooth adapter and ensures that
     * it is enabled and ready for connections.
     *
     * @return True if the bluetooth adapter
     */
    private boolean initializeBluetooth() {

        // FIXME: this might require different configs for < JELLY_BEAN_MR2, but the docs are contradictory. Revisit w/ emulator
        m_BluetoothAdapter = BluetoothAdapter.getDefaultAdapter();

        if(m_BluetoothAdapter == null)
        {
            return false;
        }

        return m_BluetoothAdapter.isEnabled() || m_BluetoothAdapter.enable();
    }

    /**
     * Connects to the server by searching the area for devices. When the server is
     * located, then the connection socket will be returned in the
     * {@link IServerConnectionListener} callback. If the server
     * connection cannot be established, the reasons will be logged and alerted.
     *
     */
    public void connectToServer() {

        if (m_BluetoothAdapter.isDiscovering() || m_ActivelySearching) {

            return;
        }

        m_ActivelySearching = true;

        // TODO check bonded devices first

        m_NearbyDevices = new ArrayList<>();
        m_BluetoothAdapter.startDiscovery();
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

                handleDeviceFound(intent);
                break;

            case BluetoothDevice.ACTION_UUID:

                handleFetchUUIDResponse(intent);

                // if we are still actively searching, we need to make sure
                // that there are devices left waiting to return their fetched
                // UUIDs. If there are not, then we had no luck finding the server.
                if(m_ActivelySearching) {

                    checkPendingFetchStatus();
                }

                break;

            case BluetoothAdapter.ACTION_DISCOVERY_STARTED:

                Debug.log("Discovery started");
                break;

            case BluetoothAdapter.ACTION_DISCOVERY_FINISHED:

                Debug.log("Discovery ended");

                handleDiscoveryFinished();
                break;
        }
    }

    private void handleDiscoveryFinished() {

        if(m_NearbyDevices.size() == 0)
        {
            m_ConnectionCallbackListener.notifyRecoverableFailure(SERVER_NOT_FOUND);
            m_ActivelySearching = false;
        }

        for(BluetoothDevice device : m_NearbyDevices)
        {
            device.fetchUuidsWithSdp(); // resumed in handleFetchUUIDResponse
        }
    }

    /**
     * Called when a device is found in the discovery. The device will
     * be added to the list of nearby devices, to be polled later.
     *
     * @param intent
     */
    private void handleDeviceFound(Intent intent) {

        BluetoothDevice foundDevice = extractDeviceFromIntent(intent);

        if(foundDevice == null)
        {
            return;
        }

        m_NearbyDevices.add(foundDevice);
    }

    /**
     * Called when the SDP poll for UUID's is complete. Searches
     * the reported UUID's for the server.
     *
     * @param intent
     */
    private void handleFetchUUIDResponse(Intent intent) {

        // no need to check if we aren't searching...
        if(m_ActivelySearching == false) {

            return;
        }

        BluetoothDevice devicePolled = extractDeviceFromIntent(intent);
        m_NearbyDevices.remove(devicePolled); // no longer keep track of this device

        Parcelable[] UUIDs = intent.getParcelableArrayExtra(BluetoothDevice.EXTRA_UUID);
        if(serverUUIDContained(UUIDs)) {

            connectToServerAndNotify(devicePolled);
            m_ActivelySearching = false;
        }
    }

    /**
     * Checks the status of pe1nding UUID fetches of nearby devices. If no
     * devices are left, then a notification will be sent to the listener
     * to alert them that the server was not found.
     */
    private void checkPendingFetchStatus() {

        if(m_NearbyDevices.size() == 0) {

            m_ConnectionCallbackListener.notifyRecoverableFailure(SERVER_NOT_FOUND);
            m_ActivelySearching = false;
        }
    }

    /**
     * Takes the given intent and determines if it is the server or not.
     *
     * @param intent
     * @return A BluetoothDevice representing the server, or null.
     */
    private BluetoothDevice extractDeviceFromIntent(Intent intent) {

        BluetoothDevice deviceFound = intent.getParcelableExtra(BluetoothDevice.EXTRA_DEVICE);

        if(deviceFound == null)
        {
            return null;
        }

        Debug.log("Found: " + deviceFound.getName() + " in discovery.");

        return deviceFound;
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
            BluetoothSocket socketConnection =
                    server.createInsecureRfcommSocketToServiceRecord(SERVER_UUID); // TODO secure

            socketConnection.connect();
            m_ConnectionCallbackListener.serverConnected(socketConnection);

            m_BluetoothAdapter.cancelDiscovery();

        } catch (IOException e) {

            Debug.logError("Could not open server connection!");
            e.printStackTrace();
            m_ConnectionCallbackListener.notifyRecoverableFailure(SOCKET_CONNECTION_FAILED);
        }

    }

    /**
     * Checks the list of UUID's for the server.
     * @param uuidList
     * @return True if found, false otherwise.
     */
    private boolean serverUUIDContained(Parcelable[] uuidList) {

        if(uuidList == null) return false;

        for(int i = 0; i < uuidList.length; i++)
        {
            String UUID = uuidList[i].toString();
            Debug.log("Found UUID " + UUID);

            if(UUID.equalsIgnoreCase(SERVER_ID))
            {
                Debug.log("Found server.");
                return true;
            }
        }

        return false;
    }

}
