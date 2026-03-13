namespace InputCommandTest;

using Godot;

public partial class Terminal : Node3D
{
    [Export]
    private Node3D? _droneSpawn;

    [Export]
    private PackedScene? _droneScene;

    private Drone? _drone;

    public override void _Ready()
    {
        _drone = _droneScene!.Instantiate<Drone>();
    }

    // TODO: don't assume Player, use an interface
    public void Interact(Player player)
    {
        GD.Print("Terminal Interacted!");

        AddChild(_drone);
        _drone!.GlobalPosition = _droneSpawn!.GlobalPosition;

        /*
        // switch actor to drone (TODO: I don't like this)
        InputManager.Instance.Actor = GetNode<Node>("../Drone");

        // update the input context
        InputManager.Instance.PushContext(ResourceLoader.Load<InputContext>("res://DroneContext.tres"));

        // update to the drone camera
        GetNode<Camera3D>("../Drone/Camera").MakeCurrent();
        */
    }

    public void _on_interact_body_entered(Node3D body)
    {
        if (body is Player player)
        {
            GD.Print("player enter");
            player.CurrentInteractable = this;
        }
    }

    public void _on_interact_body_exited(Node3D body)
    {
        if (body is Player player)
        {
            GD.Print("player exit");
            if (player.CurrentInteractable == this)
            {
                player.CurrentInteractable = null;
            }
        }
    }
}
