namespace InputCommandTest.InputCommands;

using Godot;

// TODO: IInputCommand
public interface ICommand
{
    // TODO: these having default impls is causing bugs lol

    bool Pressed(Node3D? actor) => false;

    bool Released(Node3D? actor) => false;

    bool Update(Node3D? actor, Vector2 value) => false;
}
