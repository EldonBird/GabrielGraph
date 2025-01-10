using Godot;
using System;
using GabrielGraph.scripts;

public partial class Sphere : CsgSphere3D {
	
	private Point3 selfPoint3;

	public Sphere(Point3 p) {
		selfPoint3 = p;
	}
	
	
	public override void _Ready() {
		
		Position = selfPoint3.position;


	}
}
