namespace Plugin.Maui.Rotatable;

public static class Rotatable
{
	static IRotatable? defaultImplementation;

	/// <summary>
	/// Provides the default implementation for static usage of this API.
	/// </summary>
	public static IRotatable Default =>
		defaultImplementation ??= new RotatableImplementation();

	internal static void SetDefault(IRotatable? implementation) =>
		defaultImplementation = implementation;
}
