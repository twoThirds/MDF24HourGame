using _24hGame.BaseTypes;
using _24hGame.Drawable;
using _24hGame.Drawable.Smart.Destructable.Controlled;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;
using System.Xml;
namespace _24hGame.Components.Rooms
{
    public class Room
    {
        public List<Entity> roomContent;
        public List<Enemy> enemies;
        public List<Projectile> projectiles;
        public List<Trap> traps;

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
            //Check for colisions
        }
        public void Draw(GameTime gameTime, Vector2 scroll)
        {
        }
    }
}
