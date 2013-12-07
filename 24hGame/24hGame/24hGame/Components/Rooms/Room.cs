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
        List<DrawableEntity> obstacles;
        List<Enemy> enemies;
        List<Projectile> projectiles;
        List<Trap> traps;
        Player player;
        bool active;
        public List<DrawableEntity> Obstacle { get { return obstacles; } set { obstacles = value; } }
        public List<Enemy> Enemies { get { return enemies; } set { enemies = value; } }
        public List<Projectile> Projectiles { get { return projectiles; } set { projectiles = value; } }
        public List<Trap> Traps { get { return traps; } set { traps = value; } }
        public Player Aplayer { get { return player; } set { player = value; } }

        public void Load(Game1 game)
        {
            //load room content
            //walls (Dumb Entity)
            //spawners
            //treasures chests
            enemies = new List<Enemy>();
            obstacles = new List<DrawableEntity>();
            //This should be moved to spawners
            enemies.Add(  (Enemy)( new Zombie() )  );
            int i;
            for (i = 0; i < enemies.Count; i++)
            {
                enemies[i].Load(game);
            }
            
        }
        public void SetActive(Player player)
        {
            this.player = player;
            int i;
            for (i = 0; i < enemies.Count; i++)
            {
                enemies[i].setTarget(player);
            }
        }
        public void SetDeactive()
        {
            this.player = null;
            int i;
            for (i = 0; i < enemies.Count; i++)
            {
                enemies[i].setTarget(null);
            }
        }
        public bool Update(GameTime gameTime, Vector2 scroll)
        {
            bool gameOver = false;
            int i;
            for (i = 0; i < enemies.Count; i++)
            {
                enemies[i].Update(gameTime);
            }
            if(player != null)
            {
                gameOver = player.Update(gameTime, this);
            }
            
            //Move objects
            //Check for colisions
            return gameOver;
        }
        public void Draw(GameTime gameTime, Vector2 scroll)
        {

            int i;
            for (i = 0; i < enemies.Count; i++)
            {
                enemies[i].Draw(gameTime);
            }
            if (player != null)
            {
                player.Draw(gameTime);
            }

        }
        public void Interact()
        {
            int i;
            for (i = 0; i < obstacles.Count; i++)
            {
                if(obstacles[i].Interactable)
                {
                    if (Vector2.Distance(player.Position, obstacles[i].Position) < obstacles[i].InteractDistance)
                    {
                    }
                }
            }
        }
    }
}
