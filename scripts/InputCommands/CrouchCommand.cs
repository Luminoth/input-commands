namespace InputCommandTest.InputCommands;

using Godot;

[GlobalClass]
public partial class CrouchCommand : Resource, ICommand
{
    public bool Pressed(Node3D? actor)
    {
        if (actor is ICharacter character)
        {
            character.CrouchPressed();
            return true;
        }

        return false;
    }

    public bool Released(Node3D? actor)
    {
        if (actor is ICharacter character)
        {
            character.CrouchReleased();
            return true;
        }

        return false;
    }
}
