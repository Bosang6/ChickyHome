# ChickyHome 🐥

A small 3D maze game developed in **Unity**, combining **photogrammetry** and interactive gameplay.

The project explores the complete workflow of reconstructing a real-world object from photographs, optimizing it for real-time rendering, and integrating it into a playable game.

## Technologies

- **Unity / C#** – Game development and gameplay logic
- **3DF Zephyr** – Photogrammetry and 3D reconstruction
- **Blender** – Mesh optimization and cleanup
- **Unity Line Renderer** – Interactive path drawing
- **Unity Physics** – Collision detection

## Development Workflow

1. **Photo Acquisition:** Captured approximately 30–40 photographs from different angles with sufficient overlap.
2. **3D Reconstruction:** Used 3DF Zephyr to process the photographs and generate a textured 3D mesh.
3. **Mesh Optimization:** Simplified the mesh, removed artifacts, and adjusted its geometry in Blender.
4. **Unity Integration:** Imported the optimized model into Unity and implemented the maze gameplay.

## Gameplay

The goal is to guide the character through a maze by drawing a path with the mouse.

- Hold the **left mouse button** to draw a path.
- Release the button to make the character follow the trajectory.
- Avoid colliding with walls, or the path must be redrawn.
- Reach the destination to complete the level.
- Receive visual feedback through colored paths and view your completion time.

## Play & Video

- 🎮 **[Play ChickyHome on itch.io](https://bosang.itch.io/chickyhome)**
- 🎬 **[Watch Gameplay Demo on YouTube](https://www.youtube.com/watch?v=3fK4MYpcK30)**
