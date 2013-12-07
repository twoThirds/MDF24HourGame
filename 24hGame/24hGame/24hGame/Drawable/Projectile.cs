using _24hGame.BaseTypes;
using _24hGame.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _24hGame.Drawable
{
    class Projectile : SmartEntity
    {
        Vector2 position;
        Vector2 direction;

        float projectileWidth; // Used for finding hits
        TexturedQuad texture;
    }
}
