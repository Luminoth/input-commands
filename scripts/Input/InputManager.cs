namespace InputCommandTest.Input;

using Godot;

using System.Collections.Generic;

public partial class InputManager : Node
{
    public static InputManager? Instance { get; private set; }

    private readonly Stack<InputContext> _contextStack = new();

    public void PushContext(InputContext context) => _contextStack.Push(context);

    public void PopContext() => _contextStack.Pop();

    public override void _Ready()
    {
        Instance = this;

        // TODO: disable _Process / _Input / _UnhandledInput on server
    }

    public override void _Process(double delta)
    {
        if (_contextStack.Count == 0)
        {
            GD.PushWarning("Empty context stack for process");
            return;
        }

        var currentContext = _contextStack.Peek();
        currentContext.Process();
    }

    public override void _Input(InputEvent @event)
    {
        if (_contextStack.Count == 0)
        {
            GD.PushWarning("Empty context stack for input");
            return;
        }

        var currentContext = _contextStack.Peek();
        currentContext.HandleInput(@event);
    }

    public override void _UnhandledInput(InputEvent @event)
    {
        if (_contextStack.Count == 0)
        {
            return;
        }

        var currentContext = _contextStack.Peek();
        currentContext.HandleUnhandledInput(@event);
    }
}
