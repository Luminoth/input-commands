using Godot;

public partial class Player : CharacterBody3D, ICharacter
{
    [Export]
    private InputContext _inputContext;

    public Vector2 MoveDirection { get; set; }

    [Export]
    private float _moveSpeed = 14.0f;

    [Export]
    private float _jumpVelocity = 25.0f;

    [Export]
    private float _fallAcceleration = 75.0f;

    [Export]
    private Node3D _pivot;

    public Node3D Pivot => _pivot;

    private Vector3 _targetVelocity = Vector3.Zero;

    public override void _Ready()
    {
        InputManager.Instance.Actor = this;
        InputManager.Instance.PushContext(_inputContext);
    }

    public override void _PhysicsProcess(double delta)
    {
        if (MoveDirection != Vector2.Zero)
        {
            MoveDirection = MoveDirection.Normalized();
            //_pivot.Basis = Basis.LookingAt(new Vector3(MoveDirection.X, 0.0f, MoveDirection.Y));
        }

        if (MoveDirection != Vector2.Zero)
        {
            _targetVelocity.X = MoveDirection.X * _moveSpeed;
            _targetVelocity.Z = MoveDirection.Y * _moveSpeed;
        }
        else
        {
            _targetVelocity.X = Mathf.MoveToward(Velocity.X, 0, _moveSpeed);
            _targetVelocity.Z = Mathf.MoveToward(Velocity.Z, 0, _moveSpeed);
        }

        if (!IsOnFloor())
        {
            _targetVelocity.Y -= _fallAcceleration * (float)delta;
        }

        Velocity = _targetVelocity;
        MoveAndSlide();
    }

    public void Jump()
    {
        if (IsOnFloor())
        {
            _targetVelocity.Y = _jumpVelocity;
        }
    }
}
