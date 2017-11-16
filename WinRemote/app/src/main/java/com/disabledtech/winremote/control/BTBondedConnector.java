package com.disabledtech.winremote.control;

import android.bluetooth.BluetoothAdapter;
import android.bluetooth.BluetoothDevice;
import android.bluetooth.BluetoothSocket;
import android.os.AsyncTask;

import com.disabledtech.winremote.interfaces.IBondedConnectorListener;
import com.disabledtech.winremote.utils.Debug;

import java.io.IOException;
import java.util.Set;

import javax.annotation.CheckForNull;

/**
 * This class is responsible for attempting to establish connections to pre-bonded devices.
 * It is given a list of potential devices, and attempts to establish a connection to the
 * server from them. If this operation is successful, the socket connection will be returned
 * via the {@link IBondedConnectorListener} callback method.
 */
public class BTBondedConnector extends AsyncTask<Void, Void, BluetoothSocket>
{
	Set<BluetoothDevice> m_PotentialDevices;
	IBondedConnectorListener m_ConnectorListener;

	/**
	 * @param potentialDevices A list of potential servers to attempt connection to.
	 *                            Likely obtained from {@link BluetoothAdapter#getBondedDevices()}
	 * @param listener The callback listener to be notified of the results of the connection attempt.
	 */
	public BTBondedConnector(Set<BluetoothDevice> potentialDevices, IBondedConnectorListener listener)
	{
		this.m_PotentialDevices = potentialDevices;
		this.m_ConnectorListener = listener;
	}

	@Override
	protected BluetoothSocket doInBackground(Void... params)
	{
		for(BluetoothDevice device : m_PotentialDevices)
		{
			Debug.log("Attempting connection with prior bonded device " + device.getName());

			BluetoothSocket serverSocket = attemptServerConnection(device);

			if (serverSocket != null)
			{
				return serverSocket;
			}
		}

		return null;
	}

	/**
	 * Attempts to connect to the server, returning the socket connection.
	 *
	 * @param server
	 * @return The connected socket, or null if connection failed.
	 */
	private BluetoothSocket attemptServerConnection(@CheckForNull BluetoothDevice server)
	{
		try
		{
			BluetoothSocket socketConnection =
					server.createInsecureRfcommSocketToServiceRecord(BTConnectionClient.SERVER_UUID); // TODO secure

			socketConnection.connect();

			Debug.log("Successfully paired with " + server.getName());

			return socketConnection;
		}
		catch(IOException io)
		{
			return null;
		}
	}

	@Override
	protected void onPostExecute(BluetoothSocket bluetoothSocket)
	{
		m_ConnectorListener.serverConnectorResult(bluetoothSocket);
	}
}
