namespace InputCommandTest;

using Godot;

public partial class Camera : Node3D
{
    [Export]
    private string _name = string.Empty;

    [Export]
    private Node3D? _phantomCameraNode;

    [Export]
    private int _priority = 0;

    public override void _Ready()
    {
        if (!string.IsNullOrWhiteSpace(_name))
        {
            var pcam = CameraManager.Instance!.RegisterCamera(_name, _phantomCameraNode!);
            pcam.Priority = _priority;
        }
    }
}
