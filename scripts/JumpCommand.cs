using Godot;

[GlobalClass]
public partial class JumpCommand : Resource, ICommand
{
    public bool Execute(Node actor)
    {
        if (actor is ICharacter character)
        {
            character.Jump();
            return true;
        }

        return false;
    }
}
