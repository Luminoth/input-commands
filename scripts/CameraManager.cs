namespace InputCommandTest;

using Godot;

using System.Collections.Generic;

using PhantomCamera;

public partial class CameraManager : Node
{
    public static CameraManager? Instance { get; private set; }

    private Dictionary<string, PhantomCamera3D> _cameras = [];

    public override void _Ready()
    {
        Instance = this;
    }

    public PhantomCamera3D RegisterCamera(string cameraName, Node3D cameraNode)
    {
        var camera = cameraNode.AsPhantomCamera3D();
        _cameras[cameraName] = camera;
        return camera;
    }

    public PhantomCamera3D? GetCamera(string name)
    {
        return _cameras.GetValueOrDefault(name);
    }

    public void SetCameraActive(string cameraName)
    {
        foreach (var pcam in _cameras.Values)
        {
            pcam.Priority = 0;
        }
        _cameras[cameraName].Priority = 1;
    }
}
