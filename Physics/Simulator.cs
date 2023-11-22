using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Pinballers.Physics;

public class Simulator : GameComponent
{
    public List<SimulatedObject> SimulatedObjects = new();
    
    public Simulator(Game game) : base(game)
    {
    }

    public override void Update(GameTime gameTime)
    {
        /*
         * Update physics here
         * - Progress dynamic objects
         * - Check collisions of dynamic objects with static objects and other dynamic objects
         * - Handle collisions by updating dynamic objects accordingly
         */

        foreach (var dynamicObject in SimulatedObjects)
        {
            if (dynamicObject.Type == ObjectType.Dynamic)
            {
                foreach (var otherObject in SimulatedObjects)
                {
                    // dynamicObject.CheckCollision(otherObject);
                }
            }
        }
    }
}