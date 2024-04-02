using Godot;
using Godot.Collections;

public partial class Alien : CharacterBody2D {

    [Export] PackedScene minionPrefab;
    [Export] int radius;
    
    public override void _Ready() {
        SpawnMinions((int)GD.RandRange(4, 8));
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
        Vector2 position = new Vector2();
        position.X = radius * Mathf.Cos(degree);
        position.Y = radius * Mathf.Sin(degree);
        return position;
    }

}
