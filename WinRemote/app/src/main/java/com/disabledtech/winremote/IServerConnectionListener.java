package com.disabledtech.winremote;

import android.bluetooth.BluetoothSocket;

public interface IServerConnectionListener {

    public void serverConnected(BluetoothSocket connectedSocket);

}
