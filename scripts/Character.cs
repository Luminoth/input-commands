using Godot;

public interface ICharacter
{
    Node3D Pivot { get; }

    Vector2 MoveDirection { get; set; }

    void Jump() { }
}
