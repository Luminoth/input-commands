namespace InputCommandTest;

using Godot;

public partial class FollowCamera : Camera3D
{
    [Export]
    private Node3D _followTarget;

    [Export]
    private Vector3 _followOffset = new(0.0f, 5.0f, 5.0f);

    [Export]
    private Node3D _lookAtTarget;

    public override void _Ready()
    {
        GlobalPosition = _followTarget.GlobalPosition + _followOffset;
    }

    public override void _Process(double delta)
    {
        if (_followTarget != null)
        {
            Vector3 desiredPosition = _followTarget.GlobalPosition + _followOffset;
            GlobalPosition = desiredPosition;
        }

        if (_lookAtTarget != null)
        {
            LookAt(_lookAtTarget.GlobalPosition + Vector3.Up * 1.5f, Vector3.Up);
        }
    }
}
