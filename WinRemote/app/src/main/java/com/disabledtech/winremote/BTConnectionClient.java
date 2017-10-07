package com.disabledtech.winremote;

import android.bluetooth.BluetoothAdapter;
import android.bluetooth.BluetoothDevice;
import android.bluetooth.BluetoothSocket;
import android.content.BroadcastReceiver;
import android.content.Context;
import android.content.Intent;
import android.content.IntentFilter;
import android.os.ParcelUuid;
import android.util.Log;

import java.io.IOException;
import java.util.Set;
import java.util.UUID;

/**
 * Provides a convenience class to connect to a bluetooth server.
 * This class explicity connects to a pre-processed UUID, using the
 * RFCOMM protocol and a SDP lookup of said UUID.
 */
public class BTConnectionClient extends BroadcastReceiver {

    private final String SERVER_UUID = "2BBF4D1B-9A19-4709-9399-B6AB4A88E777";
    private final UUID SERVER_ID = UUID.fromString(SERVER_UUID);

    private BluetoothAdapter bluetoothAdapter;
    private IServerConnectionListener connectionCallbackListener;

    /**
     * Initializes the bluetooth adapter and enables it
     * if it is not already enabled.
     */
    public BTConnectionClient(IServerConnectionListener listener) {

        connectionCallbackListener = listener;
        bluetoothAdapter = BluetoothAdapter.getDefaultAdapter(); // TODO diff config for < JELLY_BEAN_MR1
        if (bluetoothAdapter.isEnabled() == false) {

            bluetoothAdapter.enable(); // TODO if false
        }
    }

    /**
     * Connects to the server by first searching bonded devices,
     * and then searching the area for devices.
     */
    public void connect() { // TODO synchronous connection

        if (bluetoothAdapter.isDiscovering()) {

            bluetoothAdapter.cancelDiscovery();
        }

        try {

            BluetoothDevice server = getServerFromBondedDevices();
            BluetoothSocket socketConnection = server.createInsecureRfcommSocketToServiceRecord(SERVER_ID);
            connectionCallbackListener.serverConnected(socketConnection);
        }
        catch(IOException io)
        {
            io.printStackTrace(); // TODO
        }
        catch (ServerNotBondedException snb) {

            bluetoothAdapter.startDiscovery(); // TODO if this fails
        }
    }

    /**
     * Queries the already bonded devices for the server.
     * If the server is found, the BluetoothDevice will be
     * returned.
     *
     * @return True if the server is found, false otherwise.
     */
    private BluetoothDevice getServerFromBondedDevices() throws ServerNotBondedException {

        Set<BluetoothDevice> devices = bluetoothAdapter.getBondedDevices();

        for(BluetoothDevice device : devices)
        {
            if(device.fetchUuidsWithSdp() == false)
            {
                continue;
            }

            boolean serverFound = searchForServer(device.getUuids());

            if(serverFound)
            {
                return bluetoothAdapter.getRemoteDevice(device.getAddress());
            }
        }

        throw new ServerNotBondedException();
    }

    /**
     * Searches the list of UUID's for the server.
     * @param uuidList
     * @return True if found, false otherwise.
     */
    private boolean searchForServer(ParcelUuid[] uuidList) {

        for(int i = 0; i < uuidList.length; i++)
        {
            String UUID = uuidList[i].getUuid().toString();
            Log.d("BT", "Found UUID " + uuidList[i].getUuid().toString());

            if(UUID.equalsIgnoreCase(SERVER_UUID))
            {
                Log.d("BT", "Found server.");
                return true;
            }
        }

        return false;
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
                BluetoothDevice deviceFound = intent.getParcelableExtra(BluetoothDevice.EXTRA_DEVICE);

                if(deviceFound == null)
                {
                    break;
                }

                Log.d("BT", "Found: " + deviceFound.getName()); // TODO fix logging strategy

                if(deviceFound.fetchUuidsWithSdp())
                {
                    Log.d("BT", "UUID check passed " + deviceFound.getUuids());


                }

                break;
            case BluetoothAdapter.ACTION_DISCOVERY_STARTED:
                Log.d("BT", "Discovery started");
            case BluetoothAdapter.ACTION_DISCOVERY_FINISHED:
                Log.d("BT", "Discovery ended"); // TODO
        }
    }

}
