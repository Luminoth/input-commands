namespace InputCommandTest.InputCommands;

using Godot;

[GlobalClass]
public partial class CrouchCommand : Resource, ICommand
{
    public bool Execute(Node3D? actor)
    {
        if (actor is ICharacter character)
        {
            character.Crouch();
            return true;
        }

        return false;
    }
}
