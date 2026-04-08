# Tower of Hanoi — Animated Solver

![C#](https://img.shields.io/badge/C%23-239120?style=flat&logo=csharp&logoColor=white)
![MonoGame](https://img.shields.io/badge/MonoGame-3.8-blue?style=flat)
![.NET](https://img.shields.io/badge/.NET-6%2B-purple?style=flat)

An interactive Tower of Hanoi visualizer built with MonoGame. Solves the puzzle automatically using an iterative algorithm and animates every disc move in real time.

---

## Overview

Tower of Hanoi is a classic recursive puzzle. This project solves it **without recursion**, using the frame-method (iterative parity algorithm), and visualizes each step as a smooth three-phase disc animation — up, across, down.

The number of discs is configurable. Press **Space** to start the solver.

---

## Features

- **Iterative solver** — solves without recursion using even/odd disc parity to determine move direction each step
- **Smooth animation** — each disc moves in three phases: rise, slide, descend — driven by a move queue and per-frame updates
- **Configurable discs** — change the disc count with a single value in `Game1.cs`
- **MonoGame rendering** — draws towers and discs using primitive rectangle fills via the C3.XNA extension library

---

## Getting Started

**Prerequisites:** .NET 6 SDK or later, MonoGame 3.8+

```bash
git clone https://github.com/mohjo13/TowerOfHanoi
cd TowerOfHanoi
dotnet run
```

To change the number of discs, open `Game1.cs` and edit `stackAmount` in the constructor:

```csharp
stackAmount = 5; // ← change this
```

---

## Controls

| Key | Action |
|-----|--------|
| `Space` | Start the auto-solver and animation |
| `Escape` | Quit |

---

## How the Solver Works

The iterative frame method repeats two alternating steps until all discs reach the destination tower:

1. **Move the smallest disc** — direction (left or right) is determined by whether the total disc count is even or odd.
2. **Make the only other legal move** between the remaining two towers.

This guarantees an optimal **2ⁿ−1** move solution without any recursion. Each computed move is enqueued as a `Moves` object storing the target disc and destination position, then dequeued one at a time during the animation loop.

---

## Project Structure

| File | Description |
|------|-------------|
| `Game1.cs` | Main game loop — input, animation state machine (up / side / down), and drawing |
| `Solver.cs` | Iterative solver — computes all moves and enqueues them as `Moves` objects |
| `Moves.cs` | Move data — holds the disc being moved, its target stack, and destination coordinates |
| `Disc.cs` | Disc entity — size, position, and draw logic |
| `Tower.cs` | Tower layout — positions the three pegs relative to the screen |
| `GameConstants.cs` | Window dimensions (1000×500) |
| `Primitives2D.cs` | C3.XNA helper — `FillRectangle` and `DrawString` extensions |

---

## Built With

- [MonoGame 3.8](https://www.monogame.net/) — cross-platform game framework
- [C3.XNA](https://github.com/Nezz/MonoGame-Primitives2D) — primitive drawing helpers
- .NET 6+

---

## License

MIT
