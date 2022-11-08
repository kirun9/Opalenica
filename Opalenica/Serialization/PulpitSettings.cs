namespace Opalenica.Serialization;

using Opalenica.Tiles;

using System.Text.Json;
using System.Text.Json.Serialization;

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
        if (Settings.SerialOptions is null || Settings.SerialOptions.BaudRate is 0 || Settings.SerialOptions.PortName is null or "")
        {
            InfoTile.AddInfo("Serial port settings are not set. Please set them in settings.", InfoType.Warning);
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