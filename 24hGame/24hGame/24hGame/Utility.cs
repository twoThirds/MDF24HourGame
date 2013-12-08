using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _24hGame
{
    static class Utility
    {
        static public Vector2 AngleToV2(float angle, float length)
        {
            Vector2 direction = Vector2.Zero;
            direction.X = (float)Math.Cos(angle) * length;
            direction.Y = (float)Math.Sin(angle) * length;
            return direction;
        }

        static public float V2ToAngle(Vector2 direction)
        {
            return (float)Math.Atan2(direction.Y, direction.X);
        }
    }
}
