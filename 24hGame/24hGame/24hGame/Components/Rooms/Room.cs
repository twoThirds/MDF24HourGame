using _24hGame.BaseTypes;
using _24hGame.Drawable;
using _24hGame.Drawable.Smart.Destructable.Controlled;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Design;
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
        public void SetActive(Player player)
        {
            this.player = player;
        }
        public bool Update(GameTime gameTime, Vector2 scroll)
        {
            bool gameOver;
            gameOver = player.Update(gameTime);
            //Move objects
            //Check for colisions
            
            //List<Vector2> corners;
            //Vector2 corner;
            //corner.X = player.Position.X;
            //corners.Add(player.Position);
            //corners.Add(1,0);
            //RectangleConverter

            //if (player.Position.X)
            {
                
            }

            return gameOver;
        }
        public void Draw(GameTime gameTime, Vector2 scroll)
        {
            player.Draw(gameTime);
        }
    }
}
