using Godot;
using System;
using System.Collections.Generic;

namespace CSDebugDraw2D.Primitives;

internal partial class DebugCircleArc2D : DebugPrimitive2D
{
    public Vector2 Center = Vector2.Zero;
    public float Radius = 10;
    public float AngleFrom = 0;
    public float AngleTo = 360;
    public bool Pie = true;
    public int Resolution = 16;

    public DebugCircleArc2D(Vector2 center, float radius, float angleFrom, float angleTo, bool pie, int resolution,
        Color color, bool filled, int lineWidth, float duration)
    : base(color, filled, lineWidth, duration)
    {
        Center = center;
        Radius = radius;
        AngleFrom = angleFrom;
        AngleTo = angleTo;
        Pie = pie;
        Resolution = resolution;
    }

    public override Vector2[] GetPoints()
    {
        List<Vector2> points = [];

        if (Filled || Pie)
        {
            points.Add(Center);
        }

        for (int i = 0; i <= Resolution; i++)
        {
            double anglePoint = (AngleFrom + i * (AngleTo - AngleFrom) / Resolution - 90) * (Math.PI / 180);
            points.Add(Center + new Vector2((float)Math.Cos(anglePoint) * Radius, (float)Math.Sin(anglePoint) * Radius));
        }

        if (Pie)
        {
            points.Add(Center);
        }

        return points.ToArray();
    }
}
