using _24hGame.Components.Rooms;
using _24hGame.Drawable.Smart.Destructable.Controlled;
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
        String XMLFileName;
        Game1 game;

        public Level()
        {
            rooms = new List<Room>();
            rooms.Add(new Room());
        }
        //Takes path to an XML file and loads a level
        public void Load(String XMLFileName, Player player, Game1 game)
        {
            this.player = player;
            this.XMLFileName = XMLFileName;
            this.game = game;
            scroll = new Vector2(0, 0);
            //load each room
            int i;
            for(i = 0; i < rooms.Count; i++)
            {
                rooms[i].Load(game);
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
                if(rooms[i].Update(gameTime, scroll))
                {
                    player.Reset();
                    Load(XMLFileName, player, game);
                }
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
