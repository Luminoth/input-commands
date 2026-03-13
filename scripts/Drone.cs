namespace InputCommandTest;

using Godot;

using InputCommandTest.Input;

public partial class Drone : CharacterBody3D, ICharacter
{
    [Export]
    private InputContext? _inputContext;

    public Vector2 MoveDirection { get; set; }

    [Export]
    private float _moveSpeed = 14.0f;

    [Export]
    private Node3D? _pivot;

    public Node3D Pivot => _pivot!;

    [Export]
    private Node3D? _cameraNode;

    private Vector3 _targetVelocity = Vector3.Zero;

    public override void _Ready()
    {
        // TODO:
        //InputManager.Instance!.Actor = this;
        //InputManager.Instance.PushContext(_inputContext!);

        CameraManager.Instance!.RegisterCamera("done", _cameraNode!);
    }

    public override void _PhysicsProcess(double delta)
    {
        if (MoveDirection != Vector2.Zero)
        {
            MoveDirection = MoveDirection.Normalized();
            //_pivot.Basis = Basis.LookingAt(new Vector3(MoveDirection.X, 0.0f, MoveDirection.Y));
        }

        if (!MoveDirection.IsZeroApprox())
        {
            _targetVelocity.X = MoveDirection.X * _moveSpeed;
            _targetVelocity.Z = MoveDirection.Y * _moveSpeed;
        }
        else
        {
            _targetVelocity.X = 0.0f;//Mathf.MoveToward(Velocity.X, 0.0f, _moveSpeed);
            _targetVelocity.Z = 0.0f;//Mathf.MoveToward(Velocity.Z, 0.0f, _moveSpeed);
        }

        Velocity = _targetVelocity;
        MoveAndSlide();
    }

    public void LookAt(Vector3 point)
    {
        Pivot.LookAt(new Vector3(point.X, Pivot.GlobalPosition.Y, point.Z), Vector3.Up);
    }
}
