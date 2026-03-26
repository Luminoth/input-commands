namespace InputCommandTest.InputCommands;

using Godot;

[GlobalClass]
public partial class JumpCommand : Resource, ICommand
{
    public bool Pressed(Node3D? actor)
    {
        if (actor is ICharacter character)
        {
            character.JumpPressed();
            return true;
        }

        return false;
    }

    public bool Released(Node3D? actor)
    {
        if (actor is ICharacter character)
        {
            character.JumpReleased();
            return true;
        }

        return false;
    }
}
