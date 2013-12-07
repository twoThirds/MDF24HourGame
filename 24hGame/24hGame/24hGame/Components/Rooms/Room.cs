using _24hGame.BaseTypes;
using _24hGame.Drawable;
using _24hGame.Drawable.Smart.Destructable.Controlled;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _24hGame.Components.Rooms
{
    class Room
    {
        List<DrawableEntity> obstacle;
        List<Enemy> enemies;
        List<Projectile> projectiles;
        List<Trap> traps;
        Player player;

        public void Load()
        {
            //load room content
            //walls (Dumb Entity)
            //spawners
            //treasures chests
        }
        public void Update(GameTime gameTime, Vector2 scroll)
        {
            //Move objects
            //Check for collisions
        }
        public void Draw(GameTime gameTime, Vector2 scroll)
        {
        }
    }
}
