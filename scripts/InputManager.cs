using Godot;

using System.Collections.Generic;

public partial class InputManager : Node
{
    public static InputManager Instance { get; private set; }

    private readonly Stack<InputContext> _contextStack = new();

    // TODO: I don't like this being in here
    [Export]
    public Node Actor;

    public void PushContext(InputContext context) => _contextStack.Push(context);

    public void PopContext() => _contextStack.Pop();

    public override void _Ready()
    {
        Instance = this;
    }

    public override void _Process(double delta)
    {
        if (_contextStack.Count == 0 || Actor == null)
        {
            GD.PushWarning("Empty context stack");
            return;
        }

        var currentContext = _contextStack.Peek();

        Vector2 inputDirection = Input.GetVector(
            "move_left", "move_right",
            "move_forward", "move_backward"
        );

        if (inputDirection != Vector2.Zero)
        {
            var moveCommand = currentContext.GetCommand("movement");
            if (moveCommand == null)
            {
                GD.PushWarning("No movement command found");
            }
            moveCommand?.Execute(Actor, inputDirection);
        }
        else
        {
            var moveCommand = currentContext.GetCommand("movement");
            if (moveCommand == null)
            {
                GD.PushWarning("No movement command found");
            }
            moveCommand?.Execute(Actor, Vector2.Zero);
        }
    }

    public override void _UnhandledInput(InputEvent @event)
    {
        if (_contextStack.Count == 0 || Actor == null)
        {
            return;
        }

        InputContext currentContext = _contextStack.Peek();
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
