using Godot;

public partial class Player : CharacterBody2D {

    [Export] float speed;
    [Export] float rotationSpeed;
    [Export] PackedScene snowball;

    Sprite2D _cannon;
    Marker2D _spawnShoot;

    public override void _Ready() {
        _cannon = GetNode<Sprite2D>("Cannon");
        _spawnShoot = GetNode<Marker2D>("Cannon/ShootSpawn");
    }

    public override void _PhysicsProcess(double delta) {
        HandleShoot();
        _cannon.LookAt(GetGlobalMousePosition());
        Velocity = Transform.X * Input.GetAxis("down", "up") * speed;
        Rotation += Input.GetAxis("left", "right") * rotationSpeed;
        MoveAndSlide();
    }

    public void HandleShoot() {
        if (Input.IsActionJustPressed("shoot")) {
            Snowball projectile = (Snowball) snowball.Instantiate();
            projectile.Position = _spawnShoot.GlobalPosition;
            projectile.RotationDegrees = _cannon.RotationDegrees;
            projectile.SetDirection(GetGlobalMousePosition() - _spawnShoot.GlobalPosition);
            GetTree().Root.AddChild(projectile);
        }
    }

}
