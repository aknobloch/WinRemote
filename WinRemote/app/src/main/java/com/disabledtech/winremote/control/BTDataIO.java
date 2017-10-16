package com.disabledtech.winremote.control;

import android.bluetooth.BluetoothSocket;

import com.disabledtech.winremote.model.WinAction;
import com.disabledtech.winremote.utils.Debug;

import java.io.IOException;
import java.io.OutputStream;
import java.util.ArrayList;
import java.util.List;

/**
 * A convenience class for writing bluetooth data
 * to the server.
 *
 * Created by aknobloch on 10/7/17.
 */

public class BTDataIO {

    private BluetoothSocket m_ServerSocket;

    public BTDataIO(BluetoothSocket serverSocket)
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

    public List<WinAction> getActionData()
    {
        // TODO actually read data
        List<WinAction> dummyList = new ArrayList<>();

        dummyList.add(new WinAction("Copy", 0));
        dummyList.add(new WinAction("Paste", 1));
        dummyList.add(new WinAction("Task Manager", 2));

        Debug.log("Retrieved " + dummyList.size() + " buttons from the server.");
        return dummyList;
    }
}
