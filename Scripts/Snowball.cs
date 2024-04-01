using Godot;

public partial class Snowball : CharacterBody2D {

	[Export] float speed;

	Vector2 _velocity;
	Vector2 _direction;
	AnimatedSprite2D _anim;

    public override void _Ready() {
        _anim = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
	}
    public override void _PhysicsProcess(double delta) {
		Velocity = _direction * speed;
		MoveAndSlide();
    }

	public void SetDirection(Vector2 direction) {
		_direction = direction.Normalized();
	}

    public void OnScreenExited() {
		QueueFree();
	}

}
