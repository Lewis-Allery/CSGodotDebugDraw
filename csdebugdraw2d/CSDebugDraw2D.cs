#if TOOLS
using Godot;

namespace CSDebugDraw2D;

[Tool]
public partial class CSDebugDraw2D : EditorPlugin
{
	private const string AutoloadName = "CSDebugDraw2D";

	public override void _EnablePlugin()
    {
        // The autoload can be a scene or script file.
        AddAutoloadSingleton(AutoloadName, "res://addons/csdebugdraw2d/DebugDraw2D.cs");
    }

    public override void _DisablePlugin()
    {
        RemoveAutoloadSingleton(AutoloadName);
    }

	public override void _EnterTree()
	{
		// Initialization of the plugin goes here.
	}

	public override void _ExitTree()
	{
		// Clean-up of the plugin goes here.
	}
}
#endif
