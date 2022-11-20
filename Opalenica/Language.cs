namespace Opalenica;

using System.Globalization;
using System.Text.RegularExpressions;
using System.Resources;
using System.Diagnostics;

public static class Language
{
    private static ResourceSet rs;
    private static ResourceManager rm;

    public static bool SkipMainNamespace { get; set; } = true;

    public static void InitializeLanguage(CultureInfo selectedLanguage)
    {
        CultureAndRegionInfoBuilder.Unregister("pl-SL");
        CultureAndRegionInfoBuilder builder = new CultureAndRegionInfoBuilder("pl-SL", CultureAndRegionModifiers.None);
        var parent = CultureInfo.GetCultureInfo("pl-PL");
        builder.LoadDataFromCultureInfo(parent);
        builder.LoadDataFromRegionInfo(new RegionInfo(parent.LCID));
        builder.RegionEnglishName = "Silesia";
        builder.RegionNativeName = "Ślōnski";
        builder.CultureEnglishName = "Polish (Silesia)";
        builder.CultureNativeName = "Polski (Ślōnski)";
        builder.Register();

        selectedLanguage ??= CultureInfo.CurrentCulture;
        if (!GetSupportedLanguages().Contains(selectedLanguage)) selectedLanguage = new CultureInfo("en");
        rm = new ResourceManager("Opalenica.Strings", typeof(Program).Assembly);
        rs = rm.GetResourceSet(selectedLanguage, true, false);
        if (rs is null) throw new Exception("Selected Language " + selectedLanguage.EnglishName + " is not suppported");
        Thread.CurrentThread.CurrentCulture = selectedLanguage;
        Thread.CurrentThread.CurrentUICulture = selectedLanguage;
        CultureInfo.DefaultThreadCurrentCulture = selectedLanguage;
        CultureInfo.DefaultThreadCurrentUICulture = selectedLanguage;
        CultureInfo.CurrentCulture = selectedLanguage;
        CultureInfo.CurrentUICulture = selectedLanguage;
    }

    public static string GetString(string name)
    {
        var s = rs?.GetString(name);
        if (s is null or "")
            s = rm?.GetString(name);
        if (s is null or "")
            s = $"<{name}>";
        return s;
    }

    public static string GetString(string name, Type type, bool skipMainNamespace)
    {
        return GetString(type.FullName[(skipMainNamespace ? typeof(Language).Namespace.Length + 1 : 0)..] + "." + name);
    }

    public static string GetString(string name, Type type)
    {
        return GetString(type.FullName[(SkipMainNamespace ? typeof(Language).Namespace.Length + 1 : 0)..] + "." + name);
    }

    public static IReadOnlyCollection<CultureInfo> GetSupportedLanguages()
    {
        List<CultureInfo> supportedCultures = new List<CultureInfo>();
        var rm = new ResourceManager("Opalenica.Strings", typeof(Program).Assembly);
        foreach (var culture in CultureInfo.GetCultures(CultureTypes.AllCultures))
        {
            try
            {
                if (culture.Name is "") continue;
                ResourceSet rs = rm.GetResourceSet(culture, true, false);
                if (rs is null) continue;
                Debug.WriteLine(culture.EnglishName + " (" + culture.Name + ") is supported");
                supportedCultures.Add(culture);
            }
            catch (CultureNotFoundException)
            {
                Debug.WriteLine(culture + " is not available on the machine or is an invalid culture identifier.");
            }
        }
        return supportedCultures.AsReadOnly();
    }

    public static string LangcodeToNativeName(string langCode)
    {
        string langRegex = @"^([a-z]{2})(?:-([A-Z]{2,3}))?$";
        return Regex.IsMatch(langCode, langRegex)
            ? new CultureInfo(langCode).NativeName
            : throw new ArgumentException("Invalid language code");
    }

    public static string LangcodeToEnglishName(string langCode)
    {
        string langRegex = @"^([a-z]{2})(?:-([A-Z]{2,3}))?$";
        return Regex.IsMatch(langCode, langRegex)
            ? new CultureInfo(langCode).EnglishName
            : throw new ArgumentException("Invalid language code");
    }

    public static string LangcodeToLocalName(string langCode)
    {
        string langRegex = @"^([a-z]{2})(?:-([A-Z]{2,3}))?$";
        return Regex.IsMatch(langCode, langRegex)
            ? new CultureInfo(langCode).DisplayName
            : throw new ArgumentException("Invalid language code");
    }

    public static string NativeNameToLangcode(string name)
    {
        var culture = CultureInfo.GetCultures(CultureTypes.AllCultures).Where(e => e.NativeName == name).Select(e => e.Name).FirstOrDefault("Not found");
        return culture is "Not found" ? throw new ArgumentException("Invalid native language name") : culture;
    }

    public static string EnglishNameToLangcode(string name)
    {
        var culture = CultureInfo.GetCultures(CultureTypes.AllCultures).Where(e => e.EnglishName == name).Select(e => e.Name).FirstOrDefault("Not found");
        return culture is "Not found" ? throw new ArgumentException("Invalid english language name") : culture;
    }

    public static string LocalNameToLangcode(string name)
    {
        var culture = CultureInfo.GetCultures(CultureTypes.AllCultures).Where(e => e.DisplayName == name).Select(e => e.Name).FirstOrDefault("Not found");
        return culture is "Not found" ? throw new ArgumentException("Invalid local language name") : culture;
    }
}

