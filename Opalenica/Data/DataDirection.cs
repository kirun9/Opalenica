namespace Opalenica;

using System.Diagnostics;


[Flags]
public enum DataDirection
{
    None = 0,
    Input = 1,
    Output = 2,
    InputOutput = Input | Output
}
