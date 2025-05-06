using Godot;
using System;

namespace CSDebugDraw2D.Primitives;

internal abstract partial class DebugPrimitive2D : Node
{
     public DebugPrimitive2D(Color color, bool filled, int lineWidth, float duration)
    {
        Color = color;
        Filled = filled;
        LineWidth = lineWidth;
        DurationLeft = duration;
    }

    public double DurationLeft { get; set; } = 0;
    public bool Filled { get; } = false;
    public Color Color { get; } = new Color(1, 0, 1);
    public int LineWidth { get; } = 1;

    public abstract Vector2[] GetPoints();

}
