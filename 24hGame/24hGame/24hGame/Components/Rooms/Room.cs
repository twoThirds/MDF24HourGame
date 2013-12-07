using _24hGame.BaseTypes;
using _24hGame.Drawable;
using _24hGame.Drawable.Smart.Destructable.Contrelled;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _24hGame.Components.Rooms
{
    class Room
    {
        List<Entity> roomContent;
        List<Enemy> enemies;
        List<Projectile> projectiles;
        List<Trap> traps;

        public void Draw(GameTime gameTime, Vector2 scroll)
        {
        }
    }
}
