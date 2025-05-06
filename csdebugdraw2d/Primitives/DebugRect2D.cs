using Godot;
using System;
using System.Collections.Generic;

namespace CSDebugDraw2D.Primitives;

internal partial class DebugRect2D : DebugPrimitive2D
{
    private readonly Vector2 _center = Vector2.Zero;
    private readonly Vector2 _size = new(10, 10);

    public DebugRect2D(Vector2 center, Vector2 size, Color color, bool filled, int lineWidth, float duration)
        :base(color, filled, lineWidth, duration)
    {
        _center = center;
        _size = size;
    }

    public override Vector2[] GetPoints()
    {
        float halfX = (float)(_size.X * 0.5);
        float halfY = (float)(_size.Y * 0.5);

        List<Vector2> points = [];

        if(Filled)
        {
            points.Add(_center);
        }

        points.Add(_center + new Vector2(-halfX, halfY));
        points.Add(_center + new Vector2(halfX, halfY));
        points.Add(_center + new Vector2(halfX, -halfY));
        points.Add(_center + new Vector2(-halfX, -halfY));
        points.Add(_center + new Vector2(-halfX, halfY));

        return points.ToArray();
    }
}
