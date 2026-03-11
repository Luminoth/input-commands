namespace InputCommandTest;

using Godot;

public interface ICharacter
{
    Node3D Pivot { get; }

    Vector2 MoveDirection { get; set; }

    void LookAt(Vector3 point) { }

    void Jump() { }

    bool Interact() => false;
}
