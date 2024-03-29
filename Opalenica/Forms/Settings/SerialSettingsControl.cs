﻿namespace Opalenica.Forms.Settings;

using CommandProcessor;

using Opalenica.Serialization;
using Opalenica.Tiles;

using System;
using System.Data;
using System.IO.Ports;
using System.Linq;
using System.Windows.Forms;

public partial class SerialSettingsControl : UserControl
{
    private SerialOptions Settings;

    public SerialSettingsControl()
    {
        InitializeComponent();

        if (PulpitSettings.Settings.SerialOptions is null)
        {
            PulpitSettings.Settings.SerialOptions = new SerialOptions();
        }

        Settings = PulpitSettings.Settings.SerialOptions;

        BaudComboBox.Items.AddRange(new int[] { 300, 600, 1200, 2400, 4800, 9600, 14400, 19200, 28800, 31250, 38400, 57600, 115200 }.Select(e => e.ToString()).ToArray());
        BaudComboBox.SelectedIndex = -1;

        PortComboBox.Items.Add("Port Wewnętrzny");
        PortComboBox.SelectedIndex = -1;

        PortComboBox.Items.AddRange(SerialPort.GetPortNames().Select(e => e.ToString()).ToArray());

        bool showWarning = false;

        if (Settings.BaudRate is not 0)
        {
            BaudComboBox.SelectedItem = Settings.BaudRate.ToString();
        }
        else showWarning = true;
        if (Settings.PortName is not (null or ""))
        {
            PortComboBox.SelectedItem = Settings.PortName;
        }
        else showWarning = true;

        if (showWarning && InfoTile.CountMessagesByTag("Serial", "Settings", "Error") <= 0)
            InfoTile.AddInfo("Ustawienia portu szeregowego nie są zdefiniowane. Ustaw je w ustawieniach.", MessageSeverity.Warning, "Serial", "Settings", "Error");
        else if (!showWarning)
        {
            var message = InfoTile.GetMessageByTag("Serial", "Settings", "Error");
            if (message is not null)
                InfoTile.RemoveInfo(message.Id);
        }
    }

    internal int GetSelectedBaudRate()
    {
        if (Int32.TryParse(BaudComboBox.SelectedItem.ToString(), out int baud))
            return baud;
        else throw new InvalidCastException("Provided empty baud");
    }

    internal string GetSelectedPort()
    {
        return PortComboBox.SelectedItem as string ?? "";
    }

    private void SaveButton_Click(Object sender, EventArgs e)
    {
        Settings.BaudRate = GetSelectedBaudRate();
        Settings.PortName = GetSelectedPort();
        PulpitSettings.Settings.SerialOptions = Settings;
        PulpitSettings.SaveFile();
    }

    private void RestartButton_Click(Object sender, EventArgs e)
    {
        CommandProcessor.ExecuteCommand("serial stop");
        CommandProcessor.ExecuteCommand("serial start");
    }

    private void StartButton_Click(Object sender, EventArgs e)
    {
        CommandProcessor.ExecuteCommand("serial start");
    }
}
