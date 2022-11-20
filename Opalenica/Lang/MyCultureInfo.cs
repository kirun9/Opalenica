//namespace Opalenica.Lang;

//using System.Globalization;
//using System.Resources;

//public class MyCultureInfo : CultureInfo
//{
//    public new string EnglishName { get; private set; }
//    public new string NativeName { get; private set; }

//    public MyCultureInfo(int culture) : base(culture)
//    {
//    }

//    public MyCultureInfo(string name) : base(name)
//    {
//    }

//    public MyCultureInfo(int culture, bool useUserOverride) : base(culture, useUserOverride)
//    {
//    }

//    public MyCultureInfo(string name, bool useUserOverride) : base(name, useUserOverride)
//    {
//    }

//    public static MyCultureInfo CreateCulture(string tag, string englishName, string nativeName)
//    {
//        var c = new MyCultureInfo("");
//        c.EnglishName = englishName;
//        c.NativeName = nativeName;
//        return c;
//    }
//}

//public enum CultureAndRegionModifiers
//{
//    None = 0,
//    Replace = 1,
//    WindowsOnly = 2,
//    Framework = 4,
//    UserCustomCulture = 8,
//    UserCustomRegion = 16,
//    All = 31,
//}

//public class CultureAndRegionInfoBuilder
//{
//    public CultureAndRegionInfoBuilder(string cultureName, CultureAndRegionModifiers modifiers)
//    {
//        if (cultureName is null)
//            throw new ArgumentNullException(nameof(cultureName));
//        if (cultureName.Length == 0)
//            throw new ArgumentException("Argument_EmptyString", nameof(cultureName));
//        if (cultureName.Length > 85)
//            throw new ArgumentException("Argument_InvalidCultureName", nameof(cultureName));
//        if (!CultureAndRegionModifiers.None.Equals((object)modifiers) && !CultureAndRegionModifiers.Replace.Equals((object)modifiers))
//            throw new ArgumentException("Argument_InvalidFlag", nameof(modifiers));
//        if (CultureAndRegionModifiers.Replace.Equals((object)modifiers) && !CultureAndRegionInfoBuilder.IsReplacementCultureName(cultureName))
//            throw new ArgumentException("Argument_InvalidReplacementCultureName", nameof(cultureName));
//        this.m_cultureName = cultureName;
//        this.m_modifiers = modifiers;
//        this.m_dataItem = new CultureDataItem();
//    }

//    public CultureAndRegionInfoBuilder(string cultureName, CultureAndRegionModifiers modifiers, string parentCultureName)
//    {
//        if (cultureName is null)
//            throw new ArgumentNullException(nameof(cultureName));
//        if (cultureName.Length == 0)
//            throw new ArgumentException("Argument_EmptyString", nameof(cultureName));
//        if (cultureName.Length > 85)
//            throw new ArgumentException("Argument_InvalidCultureName", nameof(cultureName));
//        if (!CultureAndRegionModifiers.None.Equals((object)modifiers) && !CultureAndRegionModifiers.Replacement.Equals((object)modifiers))
//            throw new ArgumentException("Argument_InvalidFlag", nameof(modifiers));
//        if (CultureAndRegionModifiers.Replacement.Equals((object)modifiers) && !CultureAndRegionInfoBuilder.IsReplacementCultureName(cultureName))
//            throw new ArgumentException("Argument_InvalidReplacementCultureName", nameof(cultureName));
//        if (parentCultureName is null)
//            throw new ArgumentNullException(nameof(parentCultureName));
//        if (parentCultureName.Length == 0)
//            throw new ArgumentException("Argument_EmptyString", nameof(parentCultureName));
//        if (parentCultureName.Length > 85)
//            throw new ArgumentException("Argument_InvalidCultureName", nameof(parentCultureName));
//        this.m_cultureName = cultureName;
//        this.m_modifiers = modifiers;
//        this.m_dataItem = new CultureDataItem();
//        this.m_dataItem.Parent = parentCultureName;
//    }