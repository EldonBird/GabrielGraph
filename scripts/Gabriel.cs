namespace GabrielGraph.scripts;

using Godot;
using System;
using System.Collections.Generic;

public static partial class Gabriel {

	
	// given an entire set of points, return all possible neigbors
	public static Point[] CreateGraph(Point initial, Point[] points) {
		
		List<Point> output = new List<Point>();

			
		// we have the first point, now we need to check all other points to see if they are valid graph neigbors

		foreach (Point check in points) {

			if (initial == check) { // yourself cant be a valid neighbor
				continue;
			}

			float radius = (Mathf.Sqrt(Mathf.Pow((initial.position.X - check.position.X), 2) + 
									  Mathf.Pow((initial.position.Y - check.position.Y), 2))) * 0.5f;

			Vector2 centerpoint = new Vector2();
			centerpoint.X = (initial.position.X + check.position.X) * 0.5f;
			centerpoint.Y = (initial.position.Y + check.position.Y) * 0.5f;


			// so we are basically checking whether we have any other points in their circle
			// we are doing this by testing the distance from the center point and if it is smaller than the distance to the testing point...

			bool valid = true;
			
			foreach (Point test in points) {

				if (test == check || test == initial) {
					continue;
				}

				float distance = (Mathf.Sqrt(Mathf.Pow((centerpoint.X - test.position.X), 2) + 
											Mathf.Pow((centerpoint.Y - test.position.Y), 2))) ;

				if (distance < radius) { // INVALID NEIGHBOR
					valid = false;
					break;
				}

			}

			if (valid) {
				output.Add(check);
			}
			

		}
			
		
		
		
		return output.ToArray();
	}
	
	
	
	
	
}
