namespace Opalenica;
using System.IO.Ports;

public class MySerialPort : SerialPort
{
    public bool IsBaudRateConfigured { get; set; } = false;
    public bool IsPortNameConfigured { get; set; } = false;
    public bool IsConfigured => IsBaudRateConfigured && IsPortNameConfigured;

}