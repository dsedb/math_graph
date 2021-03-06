﻿using UnityEngine;
using System.Collections;

public class GraphManager : MonoBehaviour {

	public Material lineMat;
	private float value_ = 0f;

	void Start () {
	}
	
	public float getValue() { return value_; }
	public void setValue(float v) { value_ = v; }

	private void render_line(Vector2[] points)
	{
        GL.PushMatrix();
		GL.Begin(GL.LINES);
		int num = points.Length;
		for (int i = 0; i < num-1; ++i) {
			GL.Vertex3(points[i+0].x, points[i+0].y, 0);
			GL.Vertex3(points[i+1].x, points[i+1].y, 0);
		}
		GL.End();
		GL.PopMatrix();
	}

	void OnRenderObject ()
	{
		lineMat.SetPass(0);
		render_line(new Vector2[] { new Vector2(-100, 0), new Vector2(100, 0), });
		render_line(new Vector2[] { new Vector2(0, -100), new Vector2(0, 100), });

		const double x_step = 0.1;
		const double x_min = -20f;
		const double x_max = 20f;
		int num = (int)((x_max - x_min) / x_step);
		var points = new Vector2[num];
		double x = x_min;
		double a = value_;
		for (int i = 0; i < num; ++i) {
			double y = x*x + 2*a*x + 3*a*a-6*a-36;
			points[i] = new Vector2((float)x, (float)y);
			x += x_step;
		}
		render_line(points);
	}
}
