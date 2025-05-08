![Godot 4.0](https://img.shields.io/badge/Godot-v4.0-%23478cbf?logo=godot-engine&logoColor=white) 

https://www.nuget.org/packages/CSDebugDraw2D

# DebugDraw2D – C# Port of AlmostBearded/GodotDebugDraw  

A **C# conversion** of the original GodotDebugDraw GD scripts, providing functionality for debugging through visual shape rendering.

## Installation  

1. Copy the `csdebugdraw2d` folder into your `addons` directory (create one if necessary).  
2. Ensure your **Godot Project** has a `.sln` file and that scripts have been built at least once.  
   - Add any C# script to generate a solution file.  
   - Build the project via `dotnet build` in the terminal or using the Godot Editor.  
3. Enable the addon in **Project → Plugins**.

# Original Documentation

## Autoload Setup  

To ensure DebugDraw2D is accessible globally, you need to add it as an Autoload script.  

### Steps:  
1. Open **Project → Project Settings**.  
2. Navigate to the **Autoload** tab.  
3. Add the `DebugDraw2D` script by locating its path and naming it `DebugDraw2D`.  

Your settings should resemble this:  
![Example Autoload Setup](https://i.imgur.com/31EuOoz.png)  

## Usage  

Since `DebugDraw2D` is an Autoload, it is available **globally** in your project.  

### Available Methods:  
- `DebugDraw2D.line(...)`  
- `DebugDraw2D.rect(...)`  
- `DebugDraw2D.cube(...)`  
- `DebugDraw2D.arrow(...)`  
- `DebugDraw2D.circle(...)`  
- `DebugDraw2D.circle_arc(...)`  

### Features:  
- Draw in any color  
- Custom line width  
- Filled shapes using `DebugDraw2D...._filled()`  
- Render for a single frame or a set duration  

### Supported Primitives:  
- Lines  
- Arrows  
- Rectangles  
- Cubes  
- Circles  
- Circle Arcs / Pies
- `Polygons` 

Explore the source code for additional details—it's lightweight and easy to navigate.  

## Extensions & Contributions

Thank you to AlmostBearded for the original GD Script Library.

Need a new feature? Send me a request, and I'll consider extending the addon!  
Alternatively, feel free to enhance the source code yourself and submit a pull request—I'll review and merge useful additions.  
