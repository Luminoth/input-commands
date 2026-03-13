namespace InputCommandTest;

using Godot;

public partial class Level : Node
{
    [Export]
    Godot.Collections.Dictionary<string, Node3D> _cameraNodes = [];

    public override void _Ready()
    {
        foreach (var kvp in _cameraNodes)
        {
            CameraManager.Instance!.RegisterCamera(kvp.Key, kvp.Value);
        }
    }
}
