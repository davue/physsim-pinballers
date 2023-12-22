# PBS Group 20 - Pinballers
This is the project repository of Group 20 of the ETH lecture: Physically-Based Simulation in Computer Graphics.

[Motivational video](https://www.youtube.com/watch?v=NhVUCsXp-Uo)

## Installation
To build the project you need the [.NET 6 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/6.0). Then you should be able to build it using `dotnet build` or directly run it using `dotnet run`.

If that doesn't work you can find pre-built binaries in the [Final Release](https://github.com/davue/physsim-pinballers/releases/tag/Final).

## Controls
- `ESC`: Exit simulation
- `A` / `←`: Trigger left flipper
- `D` / `→`: Trigger right flipper
- `SPACE`: Spin both flippers
- `M`: Spawn balls in the top middle
- `Mouse Left`: (Re-)spawn ball 1 at mouse position
- `Mouse Right`: (Re-)spawn ball 2 at mouse position
- `Mouse Middle`: Spawn more balls at mouse position

## The Simulation
This is a rigid body simulation, recreating a Pinball game based on the above video built with MonoGame. As MonoGame itself doesn't have any physics engine, all the interactions between rigid objects had to be implemented from nothing. We had the following goals in mind:
- **Minimum Target:** 
  - [x] A simple setup with enclosing walls
  - [x] Only one ball
  - [x] No obstacles
  - [x] Non-controllable flippers that spin on its own
- **Desired Target:** 
  - [x] User-controllable flippers
  - [x] Some simple rigid obstacles
  - [x] Multiple balls
- **Bonus Target:** 
  - [ ] Soft-body simulated ball
  - [x] More complex obstacles (bumpers, rotating obstacles)
  - [x] Simple scoring system

We sadly did not have enough time to try soft-body simulation on our balls.