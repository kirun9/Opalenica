namespace Opalenica;

using CommandProcessor;

using Opalenica.Serialization;

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
        if (PulpitSettings.Settings.SerialOptions is not null and SerialOptions serialOptions)
        {
            serialPort.BaudRate = serialOptions.BaudRate;
            serialPort.PortName = serialOptions.PortName;
        }
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

    [RegisterCommand("serial", needConfirm: false)]
    public static bool SerialCommand(string[] args)
    {
        if (args.Length == 0)
        {
            Console.WriteLine("Missing subcommand. Usage: serial <start|stop|settings>");
            return false;
        }

        string subCommand = args[0].ToLower();

        switch (subCommand)
        {
            case "start":
                StartSerialConnection();
                break;

            case "stop":
                StopSerialConnection();
                break;

            case "settings":
                if (args.Length < 2)
                {
                    Console.WriteLine("Missing arguments for settings. Usage: serial settings <port|baud> <value>");
                    return false;
                }

                string settingType = args[1].ToLower();

                switch (settingType)
                {
                    case "port":
                        if (args.Length < 3)
                        {
                            Console.WriteLine("Missing argument for port name. Usage: serial settings port <portName>");
                            return false;
                        }

                        string portName = args[2];
                        ConfigureSerialPortName(portName);
                        break;

                    case "baud":
                        if (args.Length < 3)
                        {
                            Console.WriteLine("Missing argument for baud rate. Usage: serial settings baud <baud>");
                            return false;
                        }

                        int baudRate;

                        if (!int.TryParse(args[2], out baudRate))
                        {
                            Console.WriteLine("Invalid baud rate. Please provide a valid integer.");
                            return false;
                        }

                        ConfigureBaudRate(baudRate);
                        break;

                    default:
                        Console.WriteLine($"Unknown setting type: {settingType}. Usage: serial settings <port|baud> <value>");
                        return false;
                }
                break;

            default:
                Console.WriteLine($"Unknown subcommand: {subCommand}. Usage: serial <start|stop|settings>");
                return false;
        }

        return true;
    }

    private static void StartSerialConnection()
    {
        Instance.ConfigureSerialPort(Instance.serialPort.PortName, Instance.serialPort.BaudRate);
    }

    private static void StopSerialConnection()
    {
        Instance.Dispose();
    }

    private static void ConfigureSerialPortName(string portName)
    {
        StopSerialConnection();

        if (Instance != null)
        {
            Instance.ConfigureSerialPort(portName, Instance.serialPort.BaudRate);
            Console.WriteLine($"Serial port name configured to: {portName}");
        }
        else
        {
            Console.WriteLine("SerialManager instance is null. Cannot configure port name.");
        }
    }

    private static void ConfigureBaudRate(int baudRate)
    {
        StopSerialConnection();

        if (Instance != null)
        {
            Instance.ConfigureSerialPort(Instance.serialPort.PortName, baudRate);
            Console.WriteLine($"Baud rate configured to: {baudRate}");
        }
        else
        {
            Console.WriteLine("SerialManager instance is null. Cannot configure baud rate.");
        }
    }
}