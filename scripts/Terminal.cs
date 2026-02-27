using Godot;

// TODO:
public partial class Terminal : Node
{
    public void OnInteract(Node player)
    {
        // switch actor to drone (TODO: I don't like this)
        //InputManager.Instance.Actor = GetNode<Node>("../Drone");

        // update the input context
        //InputManager.Instance.PushContext(ResourceLoader.Load<InputContext>("res://DroneContext.tres"));

        // update to the drone camera
        //GetNode<Camera3D>("../Drone/Camera").MakeCurrent();
    }
}
