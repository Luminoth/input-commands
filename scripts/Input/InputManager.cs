namespace InputCommandTest.Input;

using Godot;

using System.Collections.Generic;

public partial class InputManager : Node
{
    public static InputManager? Instance { get; private set; }

    private readonly Stack<InputContext> _contextStack = new();

    public void PushContext(InputContext context) => _contextStack.Push(context);

    public void PopContext() => _contextStack.Pop();

    // TODO: I don't like this being in here
    [Export]
    public Node? Actor;

    // TODO: this shouldn't assume "look"
    private Vector2 _lookIntent = Vector2.Zero;

    public override void _Ready()
    {
        Instance = this;
    }

    public override void _Process(double delta)
    {
        if (_contextStack.Count == 0)
        {
            GD.PushWarning("Empty context stack");
            return;
        }

        var currentContext = _contextStack.Peek();

        // TODO: these should be configurable
        // and we shouldn't assume "move"
        Vector2 inputDirection = Input.GetVector(
            "move_left", "move_right",
            "move_forward", "move_backward"
        );


        var moveCommand = currentContext.GetCommand("movement");
        if (moveCommand == null)
        {
            GD.PushWarning("No movement command found");
        }
        moveCommand?.Execute(Actor, inputDirection);
    }

    public override void _Input(InputEvent @event)
    {
        if (@event is InputEventMouseMotion mouseMotion)
        {
            _lookIntent = mouseMotion.Relative.Normalized();
        }
    }

    public override void _UnhandledInput(InputEvent @event)
    {
        if (_contextStack.Count == 0)
        {
            return;
        }

        InputContext currentContext = _contextStack.Peek();

        // TODO; shouldn't assume "aim"
        if (!_lookIntent.IsZeroApprox())
        {
            var aimCommand = currentContext.GetCommand("aim");
            aimCommand?.Execute(Actor, _lookIntent);

            _lookIntent = Vector2.Zero;
        }

        foreach (var action in currentContext.Actions.Keys)
        {
            if (InputMap.HasAction(action) && @event.IsActionPressed(action))
            {
                var command = currentContext.GetCommand(action);
                if (command?.Execute(Actor) ?? false)
                {
                    GetViewport().SetInputAsHandled();
                    break;
                }
            }
        }
    }
}
