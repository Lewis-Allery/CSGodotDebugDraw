using CSDebugDraw2D.Primitives;
using Godot;
using System.Collections.Generic;
using System.Linq;

namespace CSDebugDraw2D;

public partial class DebugDraw2D : Node2D
{
    private static readonly Color _defaultRed = Colors.Red;
    private static readonly List<DebugPrimitive2D> _circleArcs = [];
    private static readonly List<DebugPrimitive2D> _lines = [];
    private static readonly List<DebugPrimitive2D> _rects = [];

    public override void _Ready()
    {
        SetProcess(true);
        ZIndex = 1000;
    }

    public override void _Process(double delta)
    {
        ProcessPrimitives(_circleArcs, delta);
        ProcessPrimitives(_lines, delta);
        ProcessPrimitives(_rects, delta);

        QueueRedraw();
    }

    public override void _Draw()
    {
        DrawPrimitives(_circleArcs);
        DrawPrimitives(_lines);
        DrawPrimitives(_rects);
    }

    private void ProcessPrimitives(List<DebugPrimitive2D> collection, double delta)
    {
        List<DebugPrimitive2D> primitives = collection.ToList();
        List<DebugPrimitive2D> primitivesToRemove = [];

        foreach (DebugPrimitive2D primitive in primitives)
        {
            if (primitive.DurationLeft < 0)
            {
                primitivesToRemove.Add(primitive);
            }

            primitive.DurationLeft -= delta;
        }

        foreach (DebugPrimitive2D primitive in primitivesToRemove)
        {
            collection.Remove(primitive);
        }

    }

    private void DrawPrimitives(IEnumerable<DebugPrimitive2D> collection)
    {
        //if (collection.Any()) { return; }

        List<DebugPrimitive2D> primitives = collection.ToList();

        foreach (DebugPrimitive2D primitive in primitives)
        {
            Vector2[] points = primitive.GetPoints();
            if (primitive.Filled)
            {
                if (Geometry2D.TriangulatePolygon(points).Length > 0)
                {
                    DrawPolygon(points, [primitive.Color]);
                }
            }
            else
            {
                for (int i = 0; i < points.Length - 1; i++)
                {
                    Vector2 from = points[i];
                    Vector2 to = points[i + 1];

                    DrawLine(from, to, primitive.Color, primitive.LineWidth);
                }
            }
        }
    }

    public static void Circle(Vector2 center, float radius = 10, int resolution = 16, Color? color = null, int lineWidth = 1, float duration = 0)
    {
        DebugCircleArc2D circle = new(center, radius, 0, 360, false, resolution, color ?? Colors.Red, false, lineWidth, duration);
        _circleArcs.Add(circle);
    }

    public static void CircleFilled(Vector2 center, float radius = 10, int resolution = 16, Color? color = null, int lineWidth = 1, float duration = 0)
    {
        DebugCircleArc2D circle = new(center, radius, 0, 360, false, resolution, color ?? Colors.Red, true, 1, duration);
        _circleArcs.Add(circle);
    }

    public static void CircleArc(Vector2 center, float radius = 10, float angleFrom = 0, float angleTo = 90, bool pie = true,
        int resolution = 16, Color? color = null, int lineWidth = 1, float duration = 0)
    {
        DebugCircleArc2D circle = new(center, radius, angleFrom, angleTo, pie, resolution, color ?? Colors.Red, false, 1, duration);
        _circleArcs.Add(circle);
    }

    public static void CircleArcFilled(Vector2 center, float radius = 10, float angleFrom = 0, float angleTo = 90, bool pie = true,
     int resolution = 16, Color? color = null, int lineWidth = 1, float duration = 0)
    {
        DebugCircleArc2D circle = new(center, radius, angleFrom, angleTo, pie, resolution, color ?? Colors.Red, true, 1, duration);
        _circleArcs.Add(circle);
    }

    public static void Line(Vector2 from, Vector2 to, Color? color = null, int lineWidth = 1, float duration = 0)
    {
        DebugLine2D line = new(from, to, lineWidth, duration, color ?? Colors.Red);
        _lines.Add(line);
    }

    public static void LineVector(Vector2 origin, Vector2 vector, Color? color = null, int lineWidth = 1, float duration = 0)
    {
        DebugLine2D line = new(origin, origin + vector, lineWidth, duration, color ?? Colors.Red);
        _lines.Add(line);
    }

    public static void Arrow(Vector2 from, Vector2 to, Color? color = null, int lineWidth = 1, float duration = 0)
    {
        float arrowLength = (to - from).Length();
        Vector2 arrowDirection = (to - from) / arrowLength;
        float arrowHeadSize = (float)(arrowLength * 0.25);
        Vector2 arrowHeadStart = from + arrowDirection * arrowLength * 0.75f;

        Vector2 arrowNormal = new Vector2(arrowDirection.Y, -arrowDirection.X);

        Vector2 arrowStart1 = arrowHeadStart + arrowNormal * arrowHeadSize;
        Vector2 arrowStart2 = arrowHeadStart - arrowNormal * arrowHeadSize;

        DebugLine2D line = new(from, to, lineWidth, duration, color ?? Colors.Red);
        DebugLine2D headLine1 = new(arrowStart1, to, lineWidth, duration, color ?? Colors.Red);
        DebugLine2D headLine2 = new(arrowStart2, to, lineWidth, duration, color ?? Colors.Red);

        _lines.Add(line);
        _lines.Add(headLine1);
        _lines.Add(headLine2);
    }


    public static void ArrowVector(Vector2 origin, Vector2 vector, Color? color = null, int lineWidth = 1, float duration = 0)
    {
        Arrow(origin, origin + vector, color ?? Colors.Red, lineWidth, duration);
    }

    public static void Cube(Vector2 center, float size = 10, Color? color = null, int lineWidth = 1, float duration = 0)
    {
        DebugRect2D cube = new(center, new Vector2(size, size), color ?? Colors.Red, false, lineWidth, duration);
        _rects.Add(cube);
    }

    public static void CubeFilled(Vector2 center, float size = 10, Color? color = null, int lineWidth = 1, float duration = 0)
    {
        DebugRect2D cube = new(center, new Vector2(size, size), color ?? Colors.Red, true, lineWidth, duration);
        _rects.Add(cube);
    }

    public static void Rect(Vector2 center, Vector2 size = new(), Color? color = null, int lineWidth = 1, float duration = 0)
    {
        DebugRect2D rect = new(center, size, color ?? Colors.Red, false, lineWidth, duration);
        _rects.Add(rect);
    }

    public static void RectFilled(Vector2 center, Vector2 size = new(), Color? color = null, int lineWidth = 1, float duration = 0)
    {
        DebugRect2D rect = new(center, size, color ?? Colors.Red, true, lineWidth, duration);
        _rects.Add(rect);
    }

    public static void Polygon(Vector2[] points, Color? color = null, int lineWidth = 1, float duration = 0)
    {
        int numPoints = points.Length;
        for (int i = 0; i < numPoints; i++)
        {
            var start = points[i];
            var end = points[(i + 1) % numPoints];

            DebugLine2D line = new(start, end, lineWidth, duration, Colors.Red);
            _lines.Add(line);
        }
    }

}
