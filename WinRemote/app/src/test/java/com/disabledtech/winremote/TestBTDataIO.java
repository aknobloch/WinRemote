package com.disabledtech.winremote;

import android.bluetooth.BluetoothSocket;

import com.disabledtech.winremote.control.BTDataIO;
import com.disabledtech.winremote.exceptions.ServerConnectionClosedException;
import com.disabledtech.winremote.model.WinAction;

import org.junit.Test;
import org.mockito.Matchers;
import org.mockito.Mockito;

import java.io.IOException;
import java.io.OutputStream;
import java.util.Random;

public class TestBTDataIO
{

	@Test
	public void testSend() throws Throwable
	{
		OutputStream outputStream = Mockito.mock(OutputStream.class);

		BluetoothSocket mockSocket = Mockito.mock(BluetoothSocket.class);
		Mockito.when(mockSocket.getOutputStream()).thenReturn(outputStream);

		BTDataIO dataIO = new BTDataIO(mockSocket);
		dataIO.send(new WinAction("Dummy Action", 1));

		Mockito.verify(outputStream).write(Matchers.anyInt());
	}

	@Test
	public void testValidSend() throws Throwable
	{
		OutputStream outputStream = Mockito.mock(OutputStream.class);

		BluetoothSocket mockSocket = Mockito.mock(BluetoothSocket.class);
		Mockito.when(mockSocket.getOutputStream()).thenReturn(outputStream);

		WinAction action = new WinAction("Dummy Action", new Random().nextInt());

		BTDataIO dataIO = new BTDataIO(mockSocket);
		dataIO.send(action);

		Mockito.verify(outputStream).write(action.getID());
	}

	@Test(expected = IOException.class)
	public void testGenericIOFailure() throws Throwable
	{
		BluetoothSocket mockSocket = Mockito.mock(BluetoothSocket.class);
		Mockito.when(mockSocket.getOutputStream()).thenThrow(new IOException(""));

		BTDataIO dataIO = new BTDataIO(mockSocket);
		dataIO.send(new WinAction("Dummy Action", 1));
	}

	@Test(expected = ServerConnectionClosedException.class)
	public void testServerConnectionClosed() throws Throwable
	{
		BluetoothSocket mockSocket = Mockito.mock(BluetoothSocket.class);
		Mockito.when(mockSocket.getOutputStream()).thenThrow(new IOException("Broken pipe"));

		BTDataIO dataIO = new BTDataIO(mockSocket);
		dataIO.send(new WinAction("Dummy Action", 1));
	}

	@Test
	public void testCloseConnection() throws Throwable
	{
		BluetoothSocket mockSocket = Mockito.mock(BluetoothSocket.class);

		BTDataIO dataIO = new BTDataIO(mockSocket);
		dataIO.closeConnection();

		Mockito.verify(mockSocket).close();
	}
}
