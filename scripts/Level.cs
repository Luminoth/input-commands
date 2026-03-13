namespace InputCommandTest;

using Godot;
using PhantomCamera;

// TODO: this needs to be registered with a manager
// and we need to be able to get and change the "active camera"
public partial class Level : Node
{
    // TODO: should we use a dictionary of cameras instead?

    [Export]
    private Node3D? _playerCameraNode;

    private PhantomCamera3D? _playerCamera;

    [Export]
    private Node3D? _droneCameraNode;

    private PhantomCamera3D? _droneCamera;

    public override void _Ready()
    {
        _playerCamera = _playerCameraNode!.AsPhantomCamera3D();
        _playerCamera.Priority = 1;

        _droneCamera = _droneCameraNode!.AsPhantomCamera3D();
        _droneCamera.Priority = 0;
    }
}
