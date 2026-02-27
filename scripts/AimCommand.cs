using Godot;

[GlobalClass]
public partial class AimCommand : Resource, ICommand
{
    [Export]
    private float _sensitivity = 0.2f;

    public bool Execute(Node actor, Vector2 value)
    {
        if (actor is ICharacter character)
        {
            character.Pivot.RotateY(-value.X * _sensitivity);
            return true;
        }

        return false;
    }
}
