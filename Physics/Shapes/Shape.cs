using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Pinballers.Physics.Shapes;

public abstract class Shape
{
    public abstract void Draw(SpriteBatch spriteBatch, GameTime gameTime, Color color);

    public virtual Collision GetCollision(Shape second)
        => throw new NotImplementedException();

    public virtual double GetMass()
        => throw new NotImplementedException();
}