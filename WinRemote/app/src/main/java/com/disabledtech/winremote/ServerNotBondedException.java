package com.disabledtech.winremote;

class ServerNotBondedException extends Exception {

    public ServerNotBondedException()
    {
        super("The remote server is not yet bonded to this device.");
    }
}
