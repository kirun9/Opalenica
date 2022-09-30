namespace Opalenica;
using System.Drawing;

internal struct Colors
{
	public static readonly Color None = Color.Empty;

	public static Color Black     { get; } = Color.FromArgb(0, 0, 0);
	public static Color White     { get; } = Color.FromArgb(255, 255, 255);
	public static Color Red       { get; } = Color.FromArgb(255, 0, 0);
	public static Color Yellow    { get; } = Color.FromArgb(255, 255, 0);
	public static Color Green     { get; } = Color.FromArgb(0, 255, 0);
	public static Color Cyan      { get; } = Color.FromArgb(0, 255, 255);
	public static Color Blue      { get; } = Color.FromArgb(0, 0, 255);
	public static Color Pink      { get; } = Color.FromArgb(255, 0, 255);
	public static Color Gray      { get; } = Color.FromArgb(169, 169, 169);
	public static Color Orange    { get; } = Color.FromArgb(255, 169, 0);
	public static Color LightCyan { get; } = Color.FromArgb(0, 169, 169);
	public static Color Azure     { get; } = Color.FromArgb(0, 169, 255);
	public static Color DarkRed   { get; } = Color.FromArgb(128, 0, 0);
}
