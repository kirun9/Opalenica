namespace Opalenica.Serialization;

using Opalenica.Tiles;

using System.Text.Json;

using static Opalenica.Language;

public class PulpitSettings
{
    private static Pulpit _settings;

    public static Pulpit Settings
    {
        get
        {
            if (_settings is null)
            {
                ReadFile();
                if (_settings is null)
                    throw new Exception("Cannot read settings file: Settings is null. Unknown reason");
            }
            return _settings;
        }
        set
        {
            _settings = value;
        }
    }

    private static readonly string SettingsPath = "settings.json";

    public static void CheckSettings()
    {
        if (Settings.SerialOptions is null) Settings.SerialOptions = new SerialOptions();
        if ((Settings.SerialOptions.BaudRate is 0 || Settings.SerialOptions.PortName is null or "") && InfoTile.CountMessagesByTag("Serial", "Settings", "Error") <= 0)
        {
            InfoTile.AddInfo(GetString("Messages.SerialNotSetError"), MessageSeverity.Warning, "Serial", "Settings", "Error");
        }
        else if ((Settings.SerialOptions.BaudRate is not 0 && Settings.SerialOptions.PortName is not (null or "")))
        {
            if (InfoTile.CountMessagesByTag("Serial", "Settings", "Error") > 0)
            {
                var messages = InfoTile.GetMessagesByTag("Serial", "Settings", "Error").ToArray();
                foreach (var m in messages)
                {
                    InfoTile.RemoveInfo(m.Id);
                }
            }
        }
    }

    public static void ReadFile()
    {
        {
            if (File.Exists(SettingsPath))
            {
                Settings = JsonSerializer.Deserialize<Pulpit>(File.ReadAllText(SettingsPath));
            }
            else
            {
                Settings = new Pulpit();
                SaveFile();
            }
        }
    }

    public static void SaveFile()
    {
        File.WriteAllText(SettingsPath, JsonSerializer.Serialize(Settings));
    }
}