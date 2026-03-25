namespace InputCommandTest.Input;

using Godot;

using System.Collections.Generic;

public partial class InputManager : Node
{
    public static InputManager? Instance { get; private set; }

    private readonly Stack<InputContext> _contextStack = new();

    public void PushContext(InputContext context) => _contextStack.Push(context);

    public void PopContext() => _contextStack.Pop();

    private Vector2 _cursorPosition = Vector2.Zero;

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

        Vector2 inputDirection = Input.GetVector(
            "move_left", "move_right",
            "move_forward", "move_backward"
        );

        var moveCommand = currentContext.GetCommand("movement");
        moveCommand?.Execute(currentContext.Owner, inputDirection);

        var cursorPositionCommand = currentContext.GetCommand("cursor_position");
        cursorPositionCommand?.Execute(currentContext.Owner, _cursorPosition);
    }

    public override void _Input(InputEvent @event)
    {
        if (@event is InputEventMouseMotion mouseMotion)
        {
            _cursorPosition = mouseMotion.Position;
        }
    }

    public override void _UnhandledInput(InputEvent @event)
    {
        if (_contextStack.Count == 0)
        {
            return;
        }

        InputContext currentContext = _contextStack.Peek();

        foreach (var action in currentContext.Actions.Keys)
        {
            if (InputMap.HasAction(action) && @event.IsActionPressed(action))
            {
                var command = currentContext.GetCommand(action);
                if (command?.Execute(currentContext.Owner) ?? false)
                {
                    GetViewport().SetInputAsHandled();
                    break;
                }
            }
        }
    }
}
