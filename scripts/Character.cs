using Godot;

public interface ICharacter
{
    Vector2 MoveDirection { get; set; }

    void Jump() { }
}
