package com.disabledtech.winremote.control;

import android.bluetooth.BluetoothSocket;
import android.util.JsonReader;
import android.util.Log;

import com.disabledtech.winremote.exceptions.ServerConnectionClosedException;
import com.disabledtech.winremote.model.WinAction;
import com.disabledtech.winremote.utils.Debug;
import com.google.gson.Gson;
import com.google.gson.GsonBuilder;
import com.google.gson.reflect.TypeToken;

import java.io.BufferedInputStream;
import java.io.ByteArrayOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.io.OutputStream;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

/**
 * A convenience class for writing bluetooth data
 * to the server.
 * <p>
 * Created by aknobloch on 10/7/17.
 */

public class BTDataIO
{

	private BluetoothSocket m_ServerSocket;

	public BTDataIO(BluetoothSocket serverSocket)
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
	 *
	 * @return List of all the actions provided by the server
	 */
	public List<WinAction> getActionData() throws IOException
	{
		String jsonData = readServerString();

		Debug.log("Received action data: " + jsonData);
		Gson jsonParser = new GsonBuilder().create();
		WinAction[] serverActions = jsonParser.fromJson(jsonData,  WinAction[].class);

		if(serverActions == null)
		{
			return new ArrayList<WinAction>(); // TODO exception so view can handle
		}

		List<WinAction> serverActionList = Arrays.asList(serverActions);

		Debug.log("Retrieved " + serverActionList.size() + " buttons from the server.");
		return serverActionList;
	}

	/**
	 * Reads JSON data from the server socket, returning a string
	 * of the data that was read.
	 *
	 * FIXME: This is a blocking method, but for now data is small and fast enough to be insignificant.
	 *
	 * @return
	 * @throws IOException
	 */
	public String readServerString() throws IOException
	{
		ByteArrayOutputStream bufferedOutput = new ByteArrayOutputStream();
		InputStream serverStream = m_ServerSocket.getInputStream();

		bufferedOutput.write(serverStream.read()); // blocks for beginning of server data

		while(serverStream.available() > 0)
		{
			bufferedOutput.write(serverStream.read());
		}

		bufferedOutput.flush();

		byte[] rawData = bufferedOutput.toByteArray();
		return new String(rawData, "UTF-8");
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
