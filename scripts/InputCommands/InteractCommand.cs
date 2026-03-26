namespace InputCommandTest.InputCommands;

using Godot;

[GlobalClass]
public partial class InteractCommand : Resource, ICommand
{
    public bool Pressed(Node3D? actor)
    {
        if (actor is ICharacter character)
        {
            return character.Interact();
        }
        return false;
    }
}
