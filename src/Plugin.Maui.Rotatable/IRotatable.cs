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
}