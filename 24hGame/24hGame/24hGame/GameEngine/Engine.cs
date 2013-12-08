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
        public void Initialize(String XMLFileName)
		{
			player.Initialize(game);
			level.Initialize(XMLFileName, player, game);
			Load(XMLFileName);
		}
        public void Load(String XMLFileName)
        {
            //load a new level
        }

        public void UpdateWorld(GameTime gameTime)
        {
            level.Update(gameTime);
        }
        public void RenderWorld(GameTime gameTime)
        {
            level.Draw(gameTime);
        }
    }
}
