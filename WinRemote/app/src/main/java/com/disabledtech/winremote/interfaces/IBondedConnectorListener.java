package com.disabledtech.winremote.interfaces;

import android.bluetooth.BluetoothDevice;
import android.bluetooth.BluetoothSocket;

import com.disabledtech.winremote.exceptions.BluetoothInitializationException;

import javax.annotation.CheckForNull;

/**
 * An interface for the {@link com.disabledtech.winremote.control.BTBondedConnector}
 * async task. This interface notifies the results of said task via callback.
 */
public interface IBondedConnectorListener
{
	/**
	 * The results of the server connection attempt. If the server was not
	 * found or able to be bonded to, the result will be null.
	 * @param serverSocketResult
	 */
	void serverConnectorResult(@CheckForNull BluetoothSocket serverSocketResult);
}
