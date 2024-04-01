using Godot;

public partial class Player : CharacterBody2D {

    [Export] float speed;
    [Export] float rotationSpeed;

    Sprite2D _cannon;

    public override void _Ready() {
        _cannon = GetNode<Sprite2D>("Cannon");
    }

    public override void _PhysicsProcess(double delta) {
        _cannon.LookAt(GetGlobalMousePosition());
        Velocity = Transform.X * Input.GetAxis("down", "up") * speed;
        Rotation += Input.GetAxis("left", "right") * rotationSpeed;
        MoveAndSlide();
    }

}
