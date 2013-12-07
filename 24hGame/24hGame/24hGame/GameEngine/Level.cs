using _24hGame.Components.Rooms;
using _24hGame.Drawable.Smart.Destructable.Contrelled;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _24hGame.GameEngine
{
    class Level
    {
        List<Room> rooms;
        Room currentRoom;
        Vector2 scroll;
        Player player;

        public Level()
        {
            rooms = new List<Room>();
            rooms.Add(new Room());
        }
        //Takes path to an XML file and loads a level
        public void Load(String XMLFileName, Player player)
        {
            this.player = player;
            scroll = new Vector2(0, 0);
            //load each room
            int i;
            for(i = 0; i < rooms.Count; i++)
            {
                rooms[i].Load();
            }
            this.ChangeRoom(rooms[0]);
        }
        public void ChangeRoom(Room newRoom)
        {
            newRoom.SetActive(player);
        }
        public void Update(GameTime gameTime)
        {
            //update each room
            int i;
            for (i = 0; i < rooms.Count; i++)
            {
                rooms[i].Update(gameTime, scroll);
            }
        }
        public void Draw(GameTime gameTime)
        {
            int i;
            for(i = 0; i < rooms.Count; i++)
            {
                rooms[i].Draw(gameTime, scroll);
            }
        }
    }
}
