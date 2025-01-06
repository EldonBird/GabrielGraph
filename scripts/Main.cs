namespace GabrielGraph.scripts;

using Godot;
using System;

public partial class Main : Node2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready() {

		

	}

	public override void _Draw() {
		
		DrawCircle(new Vector2(0, 0), 5, Colors.White);
		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
