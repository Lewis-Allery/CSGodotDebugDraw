using Godot;
using System;
using System.Collections.Generic;

namespace CSDebugDraw2D.Primitives;

internal partial class DebugLine2D : DebugPrimitive2D
{
        private readonly Vector2 _from = Vector2.Zero;
    private readonly Vector2 _to = Vector2.Zero;

    public DebugLine2D(Vector2 from, Vector2 to, int lineWidth, float duration, Color color)
        :base(color, false, lineWidth, duration)
    {
        _from = from;
        _to = to;
    }

    public override Vector2[] GetPoints()
    {
        List<Vector2> points = [];

        points.Add(_from);
        points.Add(_to);

        return points.ToArray();

    }
}
