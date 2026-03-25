namespace InputCommandTest;

using Godot;

using InputCommandTest.Input;

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

        if (!_drone!.IsInsideTree())
        {
            AddChild(_drone);
        }
        _drone.GlobalPosition = _droneSpawn!.GlobalPosition;

        CameraManager.Instance!.SetCameraActive("drone");
        InputManager.Instance!.PushContext(_drone.InputContext!);
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
