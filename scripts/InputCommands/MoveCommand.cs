namespace InputCommandTest.InputCommands;

using Godot;

[GlobalClass]
public partial class MoveCommand : Resource, ICommand
{
    public bool Update(Node3D? actor, Vector2 value)
    {
        if (actor is ICharacter character)
        {
            character.MoveDirection = value;
            return true;
        }
        return false;
    }
}
