using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InTheHand.Net;
using InTheHand.Net.Bluetooth;
using InTheHand.Net.Sockets;
using System.IO;

/// <summary>
/// This class contains code for searching for devices and connection.
/// This shouldn't be needed since the Windows service is a server-side 
/// connection interface.
/// </summary>
public class BTConnectionClient
{
    static List<BluetoothDeviceInfo> deviceList = new List<BluetoothDeviceInfo>();
    static readonly string SECURITY_PIN = "958671";
    static BluetoothClient bluetoothClient;

    private BTConnectionClient()
	{
        // Private to prevent instantiation - this class should not be needed.
	}

    private static void ScanForDevices()
    {
        Console.WriteLine("Begin connection.");
        bluetoothClient = new BluetoothClient();
        BluetoothComponent bluetoothComponent = new BluetoothComponent(bluetoothClient);
        
        bluetoothComponent.DiscoverDevicesProgress += new EventHandler<DiscoverDevicesEventArgs>(connectionProgress);
        bluetoothComponent.DiscoverDevicesComplete += new EventHandler<DiscoverDevicesEventArgs>(discoveryComplete);
        bluetoothComponent.DiscoverDevicesAsync(255, true, true, true, true, null);

        Console.WriteLine("Device discover began.");
        
        void connectionProgress(object sender, DiscoverDevicesEventArgs e)
        {
            for (int i = 0; i < e.Devices.Length; i++)
            {
                Console.WriteLine("Found device: " + e.Devices[i].DeviceName + " with address " + e.Devices[i].DeviceAddress);
                deviceList.Add(e.Devices[i]);
            }
        }
        
        void discoveryComplete(object sender, DiscoverDevicesEventArgs e)
        {
            Console.WriteLine("Device discovery completed.");
            RequestConnection();
        }
    }
    
    private static void RequestConnection()
    {
        if (deviceList.Count == 0)
        {
            Console.WriteLine("No devices found.");
        }

        foreach (BluetoothDeviceInfo device in deviceList)
        {
            Console.WriteLine("Attempting to pair to " + device.DeviceName);
            bool pairSuccessful = BluetoothSecurity.PairRequest(device.DeviceAddress, SECURITY_PIN); // TODO  

            if (pairSuccessful == false)
            {
                Console.WriteLine("Pair was unsuccessful.");
            }
            else
            {
                EstablishConnection(device);
            }
        }
    }
    
    private static void EstablishConnection(BluetoothDeviceInfo device)
    {
        bluetoothClient.SetPin(SECURITY_PIN);
        bluetoothClient.Connect(device.DeviceAddress, BluetoothService.SerialPort);

        Console.WriteLine("Is connected: " + bluetoothClient.Connected);

        try
        {
            System.IO.Stream dataStream = bluetoothClient.GetStream();

            while (dataStream.CanRead)
            {
                Console.WriteLine("Read from device: " + dataStream.ReadByte());
            }

            Console.WriteLine("Stream terminated.");
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: " + e.Message);
        }
    }
}
