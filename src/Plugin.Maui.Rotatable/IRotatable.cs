namespace Plugin.Maui.Rotatable;
/// <summary>
/// Provides the ability to call a property when the orientation changes.
/// </summary>
public interface IRotatable
{
	/// <summary>
	/// Called when the orientation is changed.
	/// </summary>
	bool IsPortrait { get; }
	/// <summary>
	/// Called when a property is changed.
	/// </summary>
	/// <param name="propertyName">The name of the property.</param>
	void InvokeProperty(string? propertyName);
}