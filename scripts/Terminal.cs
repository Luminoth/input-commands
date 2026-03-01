using Godot;

// TODO:
public partial class Terminal : Node
{
    /*public void OnInteract(Node player)
    {
        // switch actor to drone (TODO: I don't like this)
        InputManager.Instance.Actor = GetNode<Node>("../Drone");

        // update the input context
        InputManager.Instance.PushContext(ResourceLoader.Load<InputContext>("res://DroneContext.tres"));

        // update to the drone camera
        GetNode<Camera3D>("../Drone/Camera").MakeCurrent();
    }*/

    public void _on_interact_body_entered(Node3D body)
    {
        if (body is Player player)
        {
            GD.Print("player enter");
        }
    }

    public void _on_interact_body_exited(Node3D body)
    {
        if (body is Player player)
        {
            GD.Print("player exit");
        }
    }
}
