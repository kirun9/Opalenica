namespace Opalenica;

using System.Globalization;

static class Extensions
{
    public static bool IsHorizontal(this Size size)
    {
        return size.Width > size.Height;
    }

    public static bool IsVertical(this Size size)
    {
        return size.Height > size.Width;
    }

    public static bool IsSquare(this Size size)
    {
        return size.Width == size.Height;
    }

    public static void AddCommand(this List<string> list, string command)
    {
        while (list.Count >= Program.CommandHistoryLength)
        {
            list.Remove(list.Last());
        }
        list.Insert(1, command);
    }

    public static IEnumerable<(T item, int index)> WithIndex<T>(this IEnumerable<T> source)
    {
        return source.Select((item, index) => (item, index));
    }

    public static void SetString(this Control control, bool skipMainNamespace, Control parentControl)
    {
        control.Text = Language.GetString(control.Name, parentControl.GetType(), skipMainNamespace);
    }

    public static void SetString(this Control control, bool skipMainNamespace, bool parentNamespace)
    {
        control.Text = Language.GetString(control.Name, parentNamespace ? (control.Parent ?? control).GetType() : control.GetType(), skipMainNamespace);
    }

    public static void SetString(this Control control, bool skipMainNamespace, Control parentControl, CultureInfo targetCulture)
    {
        control.Text = Language.GetString(control.Name, parentControl.GetType(), skipMainNamespace, targetCulture);
    }

    public static void SetString(this Control control, bool skipMainNamespace, bool parentNamespace, CultureInfo targetCulture)
    {
        control.Text = Language.GetString(control.Name, parentNamespace ? (control.Parent ?? control).GetType() : control.GetType(), skipMainNamespace, targetCulture);
    }
}