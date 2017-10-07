package com.disabledtech.winremote.control;

import android.bluetooth.BluetoothSocket;

import com.disabledtech.winremote.model.WinAction;

import java.io.IOException;
import java.io.OutputStream;

/**
 * A convenience class for writing bluetooth data
 * to the server.
 *
 * Created by aknobloch on 10/7/17.
 */

public class BTDataWriter {

    private BluetoothSocket m_ServerSocket;

    public BTDataWriter(BluetoothSocket serverSocket)
    {
        m_ServerSocket = serverSocket;
    }

    /**
     * Sends the given action to the server.
     * @param action
     */
    public void send(WinAction action) throws IOException {

        int actionID = action.getID();

        OutputStream out = m_ServerSocket.getOutputStream();
        out.write(actionID);
    }
}
