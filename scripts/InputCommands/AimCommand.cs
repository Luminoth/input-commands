namespace InputCommandTest.InputCommands;

using Godot;

[GlobalClass]
public partial class AimCommand : Resource, ICommand
{
    // TODO: not here
    [Export]
    private float _sensitivity = 0.2f;

    public bool Execute(Node? actor, Vector2 value)
    {
        if (actor is ICharacter character)
        {
            // TODO: character.Aim() or something?
            character.Pivot.RotateY(-value.X * _sensitivity);
            return true;
        }

        return false;
    }
}
