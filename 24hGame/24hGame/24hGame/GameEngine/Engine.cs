using _24hGame.Components.Rooms;
using _24hGame.Drawable.Smart.Destructable.Contrelled;
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
        
        public void Load(String XMLFileName)
        {
            //load a new level
            level.Load(XMLFileName);
        }
        public void UpdateWorld(GameTime gameTime)
        {
            level.Update(gameTime);
            player.Update();
        }
        public void RenderWorld(GameTime gameTime)
        {
            level.Draw(gameTime, player);
        }
    }
}
