namespace InputCommandTest;

using Godot;

using System.Collections.Generic;

using InputCommandTest.InputCommands;

public partial class InputState : MultiplayerSynchronizer
{
    [Export]
    private Vector2 _moveDirection;

    public Vector2 MoveDirection
    {
        get => _moveDirection;

        set => _moveDirection = value;
    }

    [Export]
    private Vector2 _cursorPosition;

    public Vector2 CursorPosition
    {
        get => _cursorPosition;

        set => _cursorPosition = value;
    }

    [Export]
    private Godot.Collections.Dictionary<string, Resource> _actions = [];

    public IReadOnlyDictionary<string, Resource> Actions => _actions;

    public ICommand? GetCommand(string actionName)
    {
        if (_actions.TryGetValue(actionName, out Resource? res) && res is ICommand command)
        {
            return command;
        }
        return null;
    }
}
