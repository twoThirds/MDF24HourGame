using _24hGame.Components.Rooms;
using _24hGame.Drawable.Smart.Destructable.Contrelled;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _24hGame.Engine
{
    class Engine
    {
        Level level;
        Player player;
        public void RenderWorld(GameTime gameTime)
        {
            level.Draw(gameTime, player);
        }
    }
}
