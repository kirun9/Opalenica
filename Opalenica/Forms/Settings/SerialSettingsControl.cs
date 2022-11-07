namespace Opalenica.Forms.Settings;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

public partial class SerialSettingsControl : UserControl
{
    public SerialSettingsControl()
    {
        InitializeComponent();
        BaudComboBox.Items.AddRange(new int[] { 300, 600, 1200, 2400, 4800, 9600, 14400, 19200, 28800, 31250, 38400, 57600, 115200 }.Select(e => e.ToString()).ToArray());
        BaudComboBox.SelectedIndex = -1;

        PortComboBox.Items.Add("InternalPort");
        PortComboBox.SelectedIndex = -1;
    }

    internal int GetSelectedBaudRate()
    {
        return (int)BaudComboBox.SelectedItem;
    }

    internal string GetSelectedPort()
    {
        return PortComboBox.SelectedItem as string ?? "";
    }
}
