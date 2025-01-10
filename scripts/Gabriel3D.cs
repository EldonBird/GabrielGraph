namespace GabrielGraph.scripts;
using Godot;
using System;
using System.Collections.Generic;


public static partial class Gabriel3D {

    public static Point3[] CreateGraph3D(Point3 initial, Point3[] points3) {
        
        List<Point3> output = new List<Point3>();

        foreach (Point3 point in points3) {

            if (point == initial) {
                continue;
            }

            Vector3 centerpoint = new Vector3();
            centerpoint.X = (initial.position.X + point.position.X) * 0.5f;
            centerpoint.Y = (initial.position.Y + point.position.Y) * 0.5f;
            centerpoint.Z = (initial.position.Z + point.position.Z) * 0.5f;

            float radius = Mathf.Sqrt((Mathf.Pow((point.position.X - initial.position.X), 2)) 
                                      + (Mathf.Pow((point.position.Y - initial.position.Y), 2)) 
                                      + (Mathf.Pow(point.position.Z - initial.position.Y, 2))) * 0.5f;

            bool valid = true;
            
            foreach (Point3 other in points3) {

                if (other == point || other == initial) {
                    continue;
                }
                
                float distance = Mathf.Sqrt((Mathf.Pow((centerpoint.X - other.position.X), 2)) 
                                          + (Mathf.Pow((centerpoint.Y - other.position.Y), 2)) 
                                          + (Mathf.Pow((centerpoint.Z - other.position.Y), 2)));

                if (distance < radius) {
                    valid = false;
                    break;
                }
            }

            if (valid) {
                output.Add(point);
            }

        }
        
        
        
        
        
        return output.ToArray();
    }
}