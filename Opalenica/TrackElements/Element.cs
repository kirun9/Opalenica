namespace Opalenica;

public class Element
{
    private readonly Guid internalGuid = Guid.NewGuid();

    public bool IsSelected => SelectedElement?.internalGuid.Equals(internalGuid) ?? false;
    public static Element? SelectedElement { get; set; }

    public void Select()
    {
        SelectedElement = this;
    }

    public static void Unselect()
    {
        SelectedElement = null;
    }
}
