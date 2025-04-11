# 🌄 Unity Procedural Terrain & Object Spawner

This repository contains a Unity-based procedural terrain generator using **Sprite Shape** and a companion object spawner system. Designed for 2D games like platformers or endless runners, this system allows developers to easily create visually dynamic terrains and spawn interactive elements or decorations on the fly.

## 🚀 Features

- 🎮 **Procedural Terrain Generation**
  - Uses Perlin noise for natural-looking height variations.
  - Customizable width, amplitude, frequency, and number of points.
  - Optional seed-based generation for reproducibility.
  
- 🌱 **Procedural Object Spawner**
  - Spawns objects along the generated terrain.
  - Customizable object prefab, offset, and spawn count.
  - Avoids spawning on boundary points for better placement.

## 📂 Scripts Overview

### 1. `ProceduralTerrain.cs`
Handles terrain generation using Unity's SpriteShape. The terrain is extended and populated with points using Perlin noise.

**Key Settings:**
- `width`: Total length of the terrain.
- `numberOfPoints`: Number of midpoints for noise-based shaping.
- `amplitude`: Vertical noise intensity.
- `frequency`: Controls terrain smoothness.
- `seed`: Deterministic terrain generation using PlayerPrefs.
- `endpoint`: Optional endpoint object to mark level completion.

### 2. `ProceduralObjectSpawner.cs`
Spawns specified objects on top of the terrain at random points with a vertical offset.

**Key Settings:**
- `shape`: Reference to the SpriteShapeController used for terrain.
- `spawningObject`: Prefab to be instantiated.
- `offset`: Y-offset to place object above terrain.
- `spawningCount`: Number of objects to spawn.

## 🛠️ How to Use

1. Import both scripts into your Unity project.
2. Add a `SpriteShapeController` to your GameObject.
3. Attach the `ProceduralTerrain` script to generate the terrain.
4. Attach the `ProceduralObjectSpawner` script to spawn objects.
5. Configure the public fields in the Inspector to suit your scene.
6. Press Play and watch your terrain generate dynamically!

## 📷 Preview (Optional)
_Add a GIF or screenshot of the system in action here._

## 📌 Requirements

- Unity 2020.3 or later
- 2D SpriteShape package installed (via Package Manager)

## 📄 License

This project is open-source and available under the [MIT License](LICENSE).


---

> Feel free to fork, use, and improve. Contributions and feedback are always welcome!
