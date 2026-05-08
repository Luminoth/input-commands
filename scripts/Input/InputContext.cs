namespace InputCommandTest.Input;

using Godot;

[GlobalClass]
public partial class InputContext : Resource
{
    public InputState? OwnerState { get; set; }

    public void Process()
    {
        Vector2 moveDirection = Input.GetVector(
            "move_left", "move_right",
            "move_forward", "move_backward"
        );
        OwnerState!.MoveDirection = moveDirection;

        // TODO: save moveDirection to the OwnerState
        /*var moveCommand = currentContext.GetCommand("movement");
        moveCommand?.Update(currentContext.Owner, inputDirection);

        var cursorPositionCommand = currentContext.GetCommand("cursor_position");
        cursorPositionCommand?.Update(currentContext.Owner, _cursorPosition);*/
    }

    public void HandleInput(InputEvent @event)
    {
        if (@event is InputEventMouseMotion mouseMotion)
        {
            OwnerState!.CursorPosition = mouseMotion.Position;
        }
    }

    public void HandleUnhandledInput(InputEvent @event)
    {
        // TODO: ???
        /*foreach (var action in currentContext.Actions.Keys)
        {
            if (InputMap.HasAction(action))
            {
                if (@event.IsActionPressed(action))
                {
                    var command = currentContext.GetCommand(action);
                    if (command?.Pressed(currentContext.Owner) ?? false)
                    {
                        GetViewport().SetInputAsHandled();
                        break;
                    }
                }
                else if (@event.IsActionReleased(action))
                {
                    var command = currentContext.GetCommand(action);
                    if (command?.Released(currentContext.Owner) ?? false)
                    {
                        GetViewport().SetInputAsHandled();
                        break;
                    }
                }
            }
        }*/
    }
}
