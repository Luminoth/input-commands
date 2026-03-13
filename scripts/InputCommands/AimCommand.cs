namespace InputCommandTest.InputCommands;

using Godot;

[GlobalClass]
public partial class AimCommand : Resource, ICommand
{
    public bool Execute(Node3D? actor, Vector2 value)
    {
        if (actor is ICharacter character)
        {
            // TODO: I don't really like this ...
            // can we get the camera from the level or the camera manager instead?
            var camera = actor.GetViewport().GetCamera3D();
            if (camera == null)
            {
                return false;
            }

            var from = camera.ProjectRayOrigin(value);
            var dir = camera.ProjectRayNormal(value);

            // plane at the player's feet
            var plane = new Plane(Vector3.Up, actor.GlobalPosition.Y);
            var intersection = plane.IntersectsRay(from, dir);
            if (intersection.HasValue)
            {
                character.LookAt(intersection.Value);
            }

            return true;
        }

        return false;
    }
}
