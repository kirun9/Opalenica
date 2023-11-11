namespace Opalenica;

using System;
using System.IO.Ports;

public sealed class SerialManager : IDisposable
{
    private static readonly SerialManager instance = new SerialManager();
    private SerialPort serialPort;

    public static SerialManager Instance => instance;

    private SerialManager()
    {
        serialPort = new SerialPort();
        serialPort.DataReceived += SerialDataReceived;
    }

    ~SerialManager()
    {
        Dispose(false);
    }

    public static void SendCommand(string command)
    {
        byte[] commandBytes = SerialCommands.GetCommand(command);
        if (commandBytes != null && commandBytes.Length == 8)
            instance.SendData(commandBytes);
    }

    private void SendData(byte[] data)
    {
        if (serialPort != null && serialPort.IsOpen)
        {
            serialPort.Write(data, 0, data.Length);
        }
        else
        {
            Console.WriteLine("Serial port is not open. Cannot send data.");
        }
    }

    private void SerialDataReceived(object sender, SerialDataReceivedEventArgs e)
    {
        // Handle received data here
        // This method will be called asynchronously when data is received
        // You can implement your logic to process the received data
    }

    public void ConfigureSerialPort(string portName, int baudRate)
    {
        serialPort.PortName = portName;
        serialPort.BaudRate = baudRate;
        try
        {
            serialPort.Open();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error opening serial port: {ex.Message}");
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    private void Dispose(bool disposing)
    {
        if (disposing)
        {
            if (serialPort != null)
            {
                if (serialPort.IsOpen)
                {
                    serialPort.Close();
                }
                serialPort.Dispose();
            }
        }
    }
}