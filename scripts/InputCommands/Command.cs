namespace InputCommandTest.InputCommands;

using Godot;

// TODO: IInputCommand
public interface ICommand
{
    // TODO: these having default impls is causing bugs lol

    bool Execute(Node3D? actor) => false;

    bool Execute(Node3D? actor, Vector2 value) => false;
}
