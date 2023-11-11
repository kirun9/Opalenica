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

        MonitorComboBox.Items.AddRange(Screen.AllScreens.Select((e, i) => GetScreenName(e, i)).ToArray());
        var monitor = GetScreenName(GetScreenFromSettings());
        if (monitor is "") monitor = GetScreenName(OpalenicaForm.actualScreen);
        MonitorComboBox.SelectedItem = monitor;
        ModeDropdown.SelectedIndex = Form.ActiveForm.WindowState is FormWindowState.Maximized ? 0 : 1;
        //LanguageComboBox.Items.AddRange(Language.GetSupportedLanguages().Select(e => e.EnglishName).ToArray());
        //LanguageComboBox.SelectedItem = Language.LangcodeToEnglishName(Opalenica.Settings.Default.Language);
    }

    public static Screen GetScreenFromSettings()
    {
        foreach (var screen in Screen.AllScreens)
        {
            //if ($"{screen.DeviceFriendlyName()}_{screen.DeviceName}" == Opalenica.Settings.Default.DefaultMonitor)
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
        /*var defaultValue = Language.LangcodeToEnglishName(Opalenica.Settings.Default.Language);
        if (LanguageComboBox.SelectedItem.ToString() != defaultValue)
        {
            _needRestart = true;
            RestartInfoLabel.SetString(true, true, Language.LangcodeToCultureInfo(Language.EnglishNameToLangcode(LanguageComboBox.SelectedItem.ToString())));
            RestartInfoLabel.Show();
            ApplyButton.Enabled = _needRestart;
        }
        else
        {
            _needRestart = false;
            RestartInfoLabel.Hide();
            ApplyButton.Enabled = true;
        }*/
    }

    private void AcceptButton_Click(object sender, EventArgs e)
    {

    }

    private void ApplyButton_Click(object sender, EventArgs e)
    {

    }
}