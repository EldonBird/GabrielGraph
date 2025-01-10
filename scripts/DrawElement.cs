using Godot;
using System;
using System.Collections.Generic;

public partial class DrawElement : Node2D {
	
	
	// going to apologize for this, I am unaware of how to use the Godot engine's rendering system, this solution will have to do
	
	private Variant drawinfo;
	
	// If we pass in a Vec2, we are drawing a line
	public DrawElement(Vector2 position) {
		drawinfo = position;
	}

	
	// Using a vector 4 for lines, {x1, y1 ,x2, y2}
	public DrawElement(Vector4 TwoPoints) {
		drawinfo = TwoPoints;
	}

	public override void _Draw() {

		if (drawinfo.VariantType == Variant.Type.Vector2) {
			
			DrawCircle(drawinfo.AsVector2() * 5, 5, Colors.White);
			
		}
		if (drawinfo.VariantType == Variant.Type.Vector4) {

			Vector2 pos1 = new Vector2(drawinfo.AsVector4().X, drawinfo.AsVector4().Y);
			Vector2 pos2 = new Vector2(drawinfo.AsVector4().Z, drawinfo.AsVector4().W);
			
			DrawLine(pos1 * 5f, pos2 * 5f, Colors.Red);
			
		}
		
	}
	
}
