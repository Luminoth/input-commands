namespace InputCommandTest.Input;

using Godot;

using System.Collections.Generic;

using InputCommandTest.InputCommands;

[GlobalClass]
public partial class InputContext : Resource
{
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
