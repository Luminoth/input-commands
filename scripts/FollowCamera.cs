using Godot;

public partial class FollowCamera : Camera3D
{
    [Export]
    private Node3D _target;

    [Export]
    private Vector3 _offset = new Vector3(0, 2, 5);

    [Export]
    private float _smoothingSpeed = 5.0f;

    public override void _Ready()
    {
        GlobalPosition = _target.GlobalPosition + _offset;
    }

    public override void _Process(double delta)
    {
        if (_target == null)
        {
            return;
        }

        Vector3 desiredPosition = _target.GlobalPosition + _offset;
        //GlobalPosition = GlobalPosition.Lerp(desiredPosition, (float)delta * _smoothingSpeed);
        GlobalPosition = desiredPosition;
        LookAt(_target.GlobalPosition + Vector3.Up * 1.5f, Vector3.Up);
    }
}
