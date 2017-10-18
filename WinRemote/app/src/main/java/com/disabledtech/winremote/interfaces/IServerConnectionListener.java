package com.disabledtech.winremote.interfaces;

import android.bluetooth.BluetoothSocket;

/**
 * Provides an interface for classes using the {@link com.disabledtech.winremote.control.BTConnectionClient}
 * and who are interested in keeping track of the connection state.
 */
public interface IServerConnectionListener
{

	/**
	 * These are codes that are notified via the callback methods
	 * to indicate various problems with connection to the server.
	 * These codes could be either recoverable errors, or
	 * critical errors (such as no bluetooth module, etc)
	 */
	enum SERVER_ERROR_CODE
	{
		/**
		 * Indicates that the device does not have support for,
		 * or has not allowed permissions to use, Bluetooth.
		 */
		C_BLUETOOTH_NOT_AVAILABLE,
		/**
		 * Indicates that the server was found,
		 * but the socket connection failed. This
		 * could be a number of reasons, but is likely just
		 * a simple IO error. Retrying is the best solution.
		 */
		R_SOCKET_CONNECTION_FAILED,
		/**
		 * Indicates the server could not be found. 
		 */
		R_SERVER_NOT_FOUND;
	}

	/**
	 * Notifies that the server has been connected and is ready
	 * to be read or written to. The given socket will have been
	 * initialized with {@link BluetoothSocket#connect()}
	 *
	 * @param connectedSocket
	 */
	public void serverConnected(BluetoothSocket connectedSocket);

	/**
	 * Notifies that a critical error has occurred while attempting
	 * to connect to the server. This can be for various reasons,
	 * which will be indicated by the code.
	 */
	public void notifyCriticalFailure(SERVER_ERROR_CODE error);

	/**
	 * Notifies that a recoverable error has occurred while attempting
	 * to connect to the server. This can be for various reasons,
	 * which will be indicated by the code.
	 */
	public void notifyRecoverableFailure(SERVER_ERROR_CODE error);

}
