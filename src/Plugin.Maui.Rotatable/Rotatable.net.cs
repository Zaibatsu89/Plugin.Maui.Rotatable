namespace Plugin.Maui.Rotatable;

public partial class RotatableImplementation : IRotatable
{
    /// <inheritdoc cref="IRotatable.IsPortrait" />
    public bool IsPortrait
    {
        get
        {
            throw new NotSupportedException();
        }
    }
}