namespace Opalenica.Forms.Settings;

using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

public partial class GeneralSettingsControl : UserControl
{
    private bool _needRestart { get; set; }
    private bool NeedRestart { get => _needRestart; set => _needRestart = RestartInfoLabel.Visible = value; }

    public GeneralSettingsControl()
    {
        InitializeComponent();

        this.RestartInfoLabel.SetString(true, true);
        this.LanguageLabel.SetString(true, true);
        this.ModeLabel.SetString(true, true);
        this.CancelButton.SetString(true, true);
        this.ApplyButton.SetString(true, true);
        this.FullScreenLabel.SetString(true, true);
        this.MonitorLabel.SetString(true, true);
        this.AcceptButton.SetString(true, true);

        MonitorComboBox.Items.AddRange(Screen.AllScreens.Select((e, i) => GetScreenName(e, i)).ToArray());
        var monitor = GetScreenName(GetScreenFromSettings());
        if (monitor is "") monitor = GetScreenName(OpalenicaForm.actualScreen);
        MonitorComboBox.SelectedItem = monitor;
        ModeDropdown.SelectedIndex = Form.ActiveForm.WindowState is FormWindowState.Maximized ? 0 : 1;
        LanguageComboBox.Items.AddRange(Language.GetSupportedLanguages().Select(e => e.EnglishName).ToArray());
        LanguageComboBox.SelectedItem = Language.LangcodeToEnglishName(Opalenica.Settings.Default.Language);
    }

    public static Screen GetScreenFromSettings()
    {
        foreach (var screen in Screen.AllScreens)
        {
            if ($"{screen.DeviceFriendlyName()}_{screen.DeviceName}" == Opalenica.Settings.Default.DefaultMonitor)
            {
                return screen;
            }
        }
        return null;
    }

    private static string GetScreenName(Screen screen)
    {
        if (screen is null) return "";
        foreach (var (sc, index) in Screen.AllScreens.WithIndex())
        {
            if (sc.DeviceName == screen.DeviceName) return GetScreenName(screen, index);
        }
        return GetScreenName(screen, -1);
    }

    private static string GetScreenName(Screen screen, int index)
    {
        return $"[{index}] {screen.DeviceFriendlyName()}" + (screen.Primary ? " (Primary)" : "");
    }

    private void LanguageComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        var defaultValue = Language.LangcodeToEnglishName(Opalenica.Settings.Default.Language);
        if (LanguageComboBox.SelectedItem.ToString() != defaultValue)
        {
            _needRestart = true;
            RestartInfoLabel.Show();
            ApplyButton.Enabled = _needRestart;
        }
        else
        {
            _needRestart = false;
            RestartInfoLabel.Hide();
            ApplyButton.Enabled = true;
        }
    }

    private void ModeDropdown_SelectedIndexChanged(Object sender, EventArgs e)
    {

    }

    private void MonitorComboBox_SelectedIndexChanged(Object sender, EventArgs e)
    {

    }
}