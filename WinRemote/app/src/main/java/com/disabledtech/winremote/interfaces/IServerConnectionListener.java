package com.disabledtech.winremote.interfaces;

import android.bluetooth.BluetoothSocket;

/**
 * Provides an interface for classes using the {@link com.disabledtech.winremote.control.BTConnectionClient}
 * and who are interested in keeping track of the connection state.
 */
public interface IServerConnectionListener {

    enum SERVER_ERROR_CODE
    {
        BLUETOOTH_NOT_AVAILABLE,
        SOCKET_CONNECTION_FAILED,
        SERVER_NOT_FOUND;
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
