using _24hGame.Components.Rooms;
using _24hGame.Drawable.Smart.Destructable.Controlled;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _24hGame.GameEngine
{
    class Engine
    {
        Level level;
        Player player;
        Game1 game;

        public Engine(Game1 game)
        {
           this.game = game;
           level = new Level();
           player = new Player();
        }
        public void Load(String XMLFileName)
        {
            player.Initialize(game);
            //load a new level
            level.Load(XMLFileName, player, game);
        }

        public void UpdateWorld(GameTime gameTime)
        {
            level.Update(gameTime);
            player.Draw(gameTime);
        }
        public void RenderWorld(GameTime gameTime)
        {
            level.Draw(gameTime);
            player.Draw(gameTime);
        }
    }
}
