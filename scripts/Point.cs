using Godot;

namespace GabrielGraph.scripts;

public class Point {
    public Vector2 position;
    public Point[] neighbors;

    public Point(Vector2 position) {
        this.position = position;
    }

}