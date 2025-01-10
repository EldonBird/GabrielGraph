using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GabrielGraph.scripts;


public partial class TwoDAnimation : Node2D
{
	// Called when the node enters the scene tree for the first time.
	
	private float size = 200;
	private int pointnum = 200;

	private Point[] points;

	private Vector4[] lines;

	private bool done;

	private List<Vector4> DrawThese;
	
	
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

		List<Vector4> tmplines = new List<Vector4>();

		foreach (Point point in points) {

			point.neighbors = Gabriel.CreateGraph(point, points);

			foreach (Point neighbor in point.neighbors) {
				
				tmplines.Add(new Vector4(point.position.X, point.position.Y, neighbor.position.X, neighbor.position.Y));
				
			}

		}
		
		lines = tmplines.ToArray();
	
		StartAnimation();
		
		
	}

	public override void _Draw() {

		if (done) {
			return;
		}
		
		foreach (Point point in points) {
			
			DrawCircle(point.position * 5, 5, Colors.White);
			

		}

		foreach (Vector4 line in DrawThese) {

			if (DrawThese.Count > 0) {
				DrawLine(new Vector2(line.X * 5f, line.Y * 5f), new Vector2(line.Z * 5f, line.W * 5f), Colors.Red);
			}
		}
		
		done = true;
	}


	public override void _Process(double delta) {
		
	}
	public async void StartAnimation() { // using side effects here becuase i cant find any equivilant
		
		foreach (Vector4 line in lines) {

			DrawThese.Add(line);

			await ToSignal(GetTree().CreateTimer(1.0f), SceneTreeTimer.SignalName.Timeout);

		}
		
	}
}
