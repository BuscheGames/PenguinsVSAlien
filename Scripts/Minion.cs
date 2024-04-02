using Godot;

public partial class Minion : CharacterBody2D {

    float _degree, _speed;
    int _radius;

    public override void _PhysicsProcess(double delta) {
        _degree += 1;
        if (_degree >= 360) _degree = 0f;
        Tween tween = GetTree().CreateTween();
        tween.TweenProperty(this, "position", NewPosition(Mathf.DegToRad(_degree)), _speed);
    }

    public void SetInfo(int radius, float degree, float speed) {
        _speed = speed;
        _radius = radius;
        _degree = degree;
    }

    Vector2 NewPosition(float degree) {
         Vector2 position = new Vector2();
        position.X = _radius * Mathf.Cos(degree);
        position.Y = _radius * Mathf.Sin(degree);
        return position;
    }

}
