using Godot;
using Godot.Collections;

public partial class Alien : CharacterBody2D {

    [Export] PackedScene minionPrefab;
    [Export] float rotationSpeed;
    [Export] int radius;
    [Export] int minions;
    
    public override void _Ready() {
        SpawnMinions(minions);
    }

    public override void _PhysicsProcess(double delta) {
        Rotation -= rotationSpeed * (float) delta;
    }

    void SpawnMinions(int number) {
        float degree = 360 / number;
        for (int i = 1; i <= number; i++) {
            Minion minion = (Minion) minionPrefab.Instantiate();
            minion.Position = GetMinionPosition(Mathf.DegToRad(degree * i));
            minion.SetInfo(radius, degree * i, i / 10);
            AddChild(minion);
        }
    }

    Vector2 GetMinionPosition(float degree) {
        return new Vector2(radius * Mathf.Cos(degree), radius * Mathf.Sin(degree));
    }

}
