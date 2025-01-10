namespace GabrielGraph.scripts;

using Godot;
using System;

public partial class Point3 {
    
    public Vector3 position;
    public Point3[] neighbors;

    public Point3(Vector3 pos) {
        position = pos;
    }

}