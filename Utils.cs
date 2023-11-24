﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Linq;

namespace Pinballers;

public class Utils
{
    // Copied from https://stackoverflow.com/questions/2519304/draw-simple-circle-in-xna
    public static Texture2D CreateCircleTexture(GraphicsDevice graphicsDevice, int dia)
    {
        Texture2D texture = new Texture2D(graphicsDevice, dia, dia);
        Color[] colorData = new Color[dia * dia];

        float r = dia / 2f;
        float rSqr = r * r;

        for (int x = 0; x < dia; x++)
        {
            for (int y = 0; y < dia; y++)
            {
                int index = x * dia + y;
                Vector2 pos = new Vector2(x - r, y - r);
                if (pos.LengthSquared() <= rSqr)
                {
                    colorData[index] = Color.White;
                }
                else
                {
                    colorData[index] = Color.Transparent;
                }
            }
        }

        texture.SetData(colorData);
        return texture;
    }
    
    public static Texture2D CreateRectangleTexture(GraphicsDevice graphicsDevice, int width, int height)
    {
        Texture2D texture = new Texture2D(graphicsDevice, width, height);
        Color[] colorData = Enumerable.Repeat(Color.White, width * height).ToArray();

        texture.SetData(colorData);
        return texture;
    }

    public static float Angle(Vector2 v)
        => (float)Math.Acos(v.X / v.Length());

    public static Vector2 ToCartesian(float r, float theta)
    {
        var (sin, cos) = Math.SinCos(theta);

        return new Vector2((float)(r * cos), (float)(r * sin));
    }
}