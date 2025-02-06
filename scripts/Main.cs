using System.Threading;

namespace GabrielGraph.scripts;

using Godot;
using System;
using System.Collections.Generic;

public partial class Main : Node2D {
	
	private float size = 200;
	private int pointnum = 500;

	private Point[] points;

	private bool done; // becuase of the godot errors for drawing stuff that doesnt exist apparently
	
	// on ready, we want to draw graph in 2D
public override void _Ready() {
	
	
	List<Point> _points = new List<Point>();
	

	// Creates a new list of points given the halton sequencing
	
	for (var i = 0; i < pointnum; i++) {

		float x = (HaltonSequence.Sequence(2, i) - 0.5f) * size;
		float y = (HaltonSequence.Sequence(3, i) - 0.5f) * size;
			
		Vector2 position = new(x, y);

		_points.Add(new Point(position));
		
	}
	
	points = _points.ToArray();

	// This portions is to find all possible neigbors for each point

	foreach (Point point in points) {

		point.neighbors = Gabriel.CreateGraph(point, points);


	}
	
	
		
	

	}

	public override void _Draw() {

		foreach (Point point in  points) {
			
			DrawCircle(point.position * 5, 5, Colors.White);

			foreach (Point neighbor in point.neighbors) {
				
				DrawLine(point.position * 5f, neighbor.position * 5f, Colors.Red);
				
			}
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		_Draw();
	}
}
