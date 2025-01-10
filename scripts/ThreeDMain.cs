namespace GabrielGraph.scripts;

using Godot;
using System;
using System.Collections.Generic;

public partial class ThreeDMain : Node3D {
	
	
	PackedScene scene = GD.Load<PackedScene>("res://ShpereGo.tscn");
	PackedScene emptyScene = GD.Load<PackedScene>("res://Empty.tscn");

	
	private float size = 500;
	private int size3D = 5;
	private int pointnum = 5;

	private Point3[] points;
	
	// on ready, we want to draw graph in 2D
	public override void _Ready() {
	
		List<Point3> _points = new List<Point3>();



		for (int p = 0; p < size3D; p++) {

			for (var i = 0; i < pointnum; i++) {

				float x = (HaltonSequence.Sequence(2, i) - 0.5f) * size;
				float y = (HaltonSequence.Sequence(3, i) - 0.5f) * size;

				Vector3 position = new(x, y, p * 10);

				_points.Add(new Point3(position));

			}

		}
		
		points = _points.ToArray();
		
		foreach (Point3 point in points) {

			point.neighbors = Gabriel3D.CreateGraph3D(point, points);
			
		}


		int index = 1;
		foreach (Point3 point in points) {


			var instance = scene.Instantiate();
			AddChild(instance);

			instance.Name = new StringName(index.ToString());

			var tmp = instance.GetNode<Node3D>(instance.GetPath());

			tmp.GlobalPosition = point.position * 0.2f;

			//instance.GetNode<Node3D>("Node3D").Position = point.position;

			index++;
		}
		
		

		foreach (Point3 point in points) {

			foreach (Point3 neighbor in point.neighbors) {

				var obj = emptyScene.Instantiate();
				
				AddChild(obj);
				
				obj.AddChild(Line(point.position * 0.2f, neighbor.position * 0.2f, Colors.Red));


			}
			
		}
		
	}
	
	public MeshInstance3D Line(Vector3 pos1, Vector3 pos2, Color? color = null)
	{
		var meshInstance = new MeshInstance3D();
		var immediateMesh = new ImmediateMesh();
		var material = new StandardMaterial3D();

		meshInstance.Mesh = immediateMesh;
		meshInstance.CastShadow = GeometryInstance3D.ShadowCastingSetting.Off;

		immediateMesh.SurfaceBegin(Mesh.PrimitiveType.Lines, material);
		immediateMesh.SurfaceAddVertex(pos1);
		immediateMesh.SurfaceAddVertex(pos2);
		immediateMesh.SurfaceEnd();

		material.ShadingMode = StandardMaterial3D.ShadingModeEnum.Unshaded;
		material.AlbedoColor = color ?? Colors.WhiteSmoke;

		(Engine.GetMainLoop() as SceneTree).Root.AddChild(meshInstance);

		return meshInstance;
	}

	public static MeshInstance3D Point(Vector3 pos, float radius = 0.05f, Color? color = null)
	{
		var meshInstance = new MeshInstance3D();
		var sphereMesh = new SphereMesh();
		var material = new StandardMaterial3D();

		meshInstance.Mesh = sphereMesh;
		meshInstance.CastShadow = GeometryInstance3D.ShadowCastingSetting.Off;
		meshInstance.Position = pos;

		sphereMesh.Radius = radius;
		sphereMesh.Height = radius * 2f;
		sphereMesh.Material = material;

		material.ShadingMode = StandardMaterial3D.ShadingModeEnum.Unshaded;
		material.AlbedoColor = color ?? Colors.WhiteSmoke;

		(Engine.GetMainLoop() as SceneTree).Root.AddChild(meshInstance);

		return meshInstance;
	}
	
}
