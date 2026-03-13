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

    public void RegisterCamera(string cameraName, Node3D cameraNode)
    {
        _cameras[cameraName] = cameraNode.AsPhantomCamera3D();
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
