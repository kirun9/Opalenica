namespace Opalenica;

using CommandProcessor;

using Opalenica.Serialization;
using Opalenica.Tiles;

using System;
using System.IO.Ports;

public sealed class SerialManager : Singleton<SerialManager>, IDisposable
{
    private MySerialPort serialPort;

    public bool IsConfigured { get => serialPort?.IsConfigured ?? false; }

    public SerialManager() : base()
    {
        serialPort = new MySerialPort();
        serialPort.DataReceived += SerialDataReceived;
        serialPort.WriteBufferSize = 64;
        serialPort.WriteTimeout = 20;
        if (PulpitSettings.Settings.SerialOptions is not null and SerialOptions serialOptions)
        {
            SetBaudRate(serialOptions.BaudRate);
            SetPortName(serialOptions.PortName);
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
            Instance.SendData(commandBytes);
    }

    private void SendData(byte[] data)
    {
        var thread = new Thread(() =>
        {
            if (serialPort != null && serialPort.IsOpen)
            {
                try
                {
                    serialPort.Write(data, 0, data.Length);
                }
                catch (TimeoutException ex)
                {
                    InfoTile.AddInfo("Upłynął limit czasu dla wysyłania danych w komunikacji szeregowej", MessageSeverity.Error, "Serial", "Error", "Timeout");
                }
            }
            else
            {
                InfoTile.AddInfo("Serial port is not open. Cannot send data.", MessageSeverity.Error, "Serial", "Error", "NotOpen");
            }
        });
        thread.Start();
    }

    private void SerialDataReceived(object sender, SerialDataReceivedEventArgs e)
    {
        // Handle received data here
        // This method will be called asynchronously when data is received
    }

    public void StartSerialPort()
    {
        if (serialPort.IsConfigured)
        {
            try
            {
                serialPort.Open();
            }
            catch (Exception ex)
            {
                InfoTile.AddInfo(ex.Message, MessageSeverity.Error, "Serial", "Exception");
            }
        }
        else
        {
            ShowBaudRateInfo(serialPort.IsBaudRateConfigured);
            ShowPortNameInfo(serialPort.IsPortNameConfigured);
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
            InfoTile.AddInfo("Missing subcommand. Usage: serial <start|stop|settings>", MessageSeverity.Help, "Serial", "Command", "HelpInfo");
            return false;
        }

        string subCommand = args[0].ToLower();

        switch (subCommand)
        {
            case "start":
                Instance.StartSerialPort();
                break;

            case "stop":
                StopSerialConnection();
                break;

            case "settings":
                if (args.Length < 2)
                {
                    InfoTile.AddInfo("Missing arguments for settings. Usage: serial settings <port|baud> <value>", MessageSeverity.Help, "Serial", "Command", "HelpInfo");
                    return false;
                }

                string settingType = args[1].ToLower();

                switch (settingType)
                {
                    case "port":
                        if (args.Length < 3)
                        {
                            InfoTile.AddInfo("Missing argument for port name. Usage: serial settings port <portName>", MessageSeverity.Help, "Serial", "Command", "HelpInfo");
                            return false;
                        }

                        string portName = args[2];
                        ConfigureSerialPortName(portName);
                        break;

                    case "baud":
                        if (args.Length < 3)
                        {
                            InfoTile.AddInfo("Missing argument for baud rate. Usage: serial settings baud <baud>", MessageSeverity.Help, "Serial", "Command", "HelpInfo");
                            return false;
                        }

                        int baudRate;

                        if (!int.TryParse(args[2], out baudRate))
                        {
                            InfoTile.AddInfo("Invalid baud rate. Please provide a valid integer.", MessageSeverity.Help, "Serial", "Command", "HelpInfo");
                            return false;
                        }

                        ConfigureBaudRate(baudRate);
                        break;

                    default:
                        InfoTile.AddInfo($"Unknown setting type: {settingType}. Usage: serial settings <port|baud> <value>", MessageSeverity.Help, "Serial", "Command", "HelpInfo");
                        return false;
                }
                break;

            default:
                InfoTile.AddInfo($"Unknown subcommand: {subCommand}. Usage: serial <start|stop|settings>", MessageSeverity.Help, "Serial", "Command", "HelpInfo");
                return false;
        }

        return true;
    }

    private static void StartSerialConnection()
    {
        Instance.SetBaudRate(Instance.serialPort.IsBaudRateConfigured ? Instance.serialPort.BaudRate : 0);
        Instance.SetPortName(Instance.serialPort.IsPortNameConfigured ? Instance.serialPort.PortName : "");
        Instance.serialPort.Open();
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
            Instance.SetPortName(portName);
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
            Instance.SetBaudRate( baudRate);
        }
        else
        {
            Console.WriteLine("SerialManager instance is null. Cannot configure baud rate.");
        }
    }

    public static bool CheckBaudRate(int value)
    {
        var avaibleBaudRates = new int[] { 300, 600, 1200, 2400, 4800, 9600, 14400, 19200, 28800, 31250, 38400, 57600, 115200 };
        return avaibleBaudRates.Contains(value);
    }

    public static bool CheckPortName(string value)
    {
        return MySerialPort.GetPortNames().Contains(value);
    }

    private void SetBaudRate(int baudRate)
    {
        if (CheckBaudRate(baudRate))
        {
            serialPort.BaudRate = baudRate;
            serialPort.IsBaudRateConfigured = true;
            ShowBaudRateInfo(false);
        }
        else
        {
            ShowBaudRateInfo(true);
        }
    }

    private void ShowBaudRateInfo(bool show)
    {
        var message = InfoTile.GetMessageByTag("Serial", "Settings", "Warning", "BaudRate");
        if (message == InfoMessage.None)
        {
            if (show)
                InfoTile.AddInfo("Ustawienia portu szeregowego są niepoprawnie zdefiniowane. Błędny parametr: Baud Rate", MessageSeverity.Warning, "Serial", "Settings", "Warning", "BaudRate");
        }
        else
        {
            if (!show)
                InfoTile.RemoveInfo(message.Id);
        }
    }

    public void SetPortName(string portName)
    {
        if (MySerialPort.GetPortNames().Contains(portName?.ToUpper()))
        {
            serialPort.PortName = portName;
            serialPort.IsPortNameConfigured = true;
            ShowPortNameInfo(false);
        }
        else
        {
            ShowPortNameInfo(true);
        }
    }

    private void ShowPortNameInfo(bool show)
    {
        var message = InfoTile.GetMessageByTag("Serial", "Settings", "Warning", "PortName");
        if (message == InfoMessage.None)
        {
            if (show)
                InfoTile.AddInfo("Ustawienia portu szeregowego są niepoprawnie zdefiniowane. Błędny parametr: Port Name", MessageSeverity.Warning, "Serial", "Settings", "Warning", "PortName");
        }
        else
        {
            if (!show)
                InfoTile.RemoveInfo(message.Id);
        }
    }
}