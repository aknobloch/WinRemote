package com.disabledtech.winremote.control;

import android.bluetooth.BluetoothSocket;

import com.disabledtech.winremote.exceptions.ServerConnectionClosedException;
import com.disabledtech.winremote.model.WinAction;
import com.disabledtech.winremote.utils.Debug;

import java.io.IOException;
import java.io.OutputStream;
import java.net.Socket;
import java.util.ArrayList;
import java.util.List;

/**
 * A convenience class for writing bluetooth data
 * to the server.
 * <p>
 * Created by aknobloch on 10/7/17.
 */

public class BTDataIO
{

	private Socket m_ServerSocket;

	public BTDataIO(Socket serverSocket)
	{
		m_ServerSocket = serverSocket;
	}

	/**
	 * Sends the given action to the server, via the action ID.
	 *
	 * @param action
	 */
	public void send(WinAction action) throws IOException, ServerConnectionClosedException
	{
		int actionID = action.getID();

		try
		{
			OutputStream out = m_ServerSocket.getOutputStream();
			out.write(actionID);
		}
		catch(IOException ioe)
		{
			// if the error is "broken pipe" it means that the server has been disconnected.
			// since we are not listening on this connection, it's hard to gracefully close.
			// FIXME: better way to check connection integrity
			if(ioe.getMessage().equalsIgnoreCase("Broken pipe"))
			{
				closeConnection();
				throw new ServerConnectionClosedException();
			}
			else
			{
				throw ioe;
			}
		}

	}

	/**
	 * Reads the initial button data from the server.
	 * TODO: not implemented yet, returns hardcoded actions
	 *
	 * @return List of all the actions provided by the server
	 */
	public List<WinAction> getActionData()
	{
		// TODO handle when server disconnects
		List<WinAction> dummyList = new ArrayList<>();

		dummyList.add(new WinAction("Copy", 1));
		dummyList.add(new WinAction("Paste", 2));
		dummyList.add(new WinAction("Select All", 3));

		Debug.log("Retrieved " + dummyList.size() + " buttons from the server.");
		return dummyList;
	}

	public void closeConnection()
	{
		try
		{
			m_ServerSocket.close();
		}
		catch (IOException e)
		{
			// TODO relinquish the underlying socket resources and internally mark the Closeable as closed (from .close() docs)
			Debug.logError("Unable to close connection.");
			e.printStackTrace();
		}
	}
}
