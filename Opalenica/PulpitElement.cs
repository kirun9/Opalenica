/*
 * namespace Opalenica;

class PulpitElement
{
    protected static int _elementID { get; private set; } = 0;

    protected int value;
    public Color ActualColor { get; set; } = Colors.None;
    public Location Location = Location.Empty;
    public bool PulsingSignal { get; set; }
    public Color SecondPulsingColor { get; set; }
    public virtual string Name { get; set; } = "PulpitElement_" + _elementID;


    public PulpitElement()
    {
        _elementID++;
    }
    protected PulpitElement(int value) { this.value = value; _elementID++; }
    public static implicit operator PulpitElement(int value) => new PulpitElement(value);
    public static implicit operator int(PulpitElement value) => value.value;
}
*/