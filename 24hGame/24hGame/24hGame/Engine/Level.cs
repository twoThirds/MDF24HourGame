﻿using _24hGame.Components.Rooms;
using _24hGame.Drawable.Smart.Destructable.Contrelled;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _24hGame.Engine
{
    class Level
    {
        List<Room> rooms;
        Room current;
        public void Draw(GameTime gameTime, Player player)
        {
            Vector2 scroll = new Vector2(0, 0);
            int i;
            for(i = 0; i < rooms.Count; i++)
            {
                rooms[i].Draw(gameTime, scroll);
            }
        }
    }
}
