using Godot;

public interface ICommand
{
    bool Execute(Node actor) => false;

    bool Execute(Node actor, Vector2 value) => false;
}
