using _24hGame.Components.Rooms;
using _24hGame.Drawable.Smart.Destructable.Contrelled;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;
using System.Xml;

namespace _24hGame.GameEngine
{
    public class Level
    {
        public List<Room> rooms;
        public Room currentRoom;
        public void Serialize<Level>(Level data, string filePath)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Level));
            //Overridden to use UTF8 for compatability with Perl XML::DOM.

            using (TextWriter writer = new StreamWriter(filePath))
            {
                xmlSerializer.Serialize(writer, data);
            }
        }

        public Level DeSerilize(Level data, string filePath)
        {
            XmlSerializer ser = new XmlSerializer(typeof(Level));

            using (XmlReader reader = XmlReader.Create(filePath))
            {
                data = (Level)ser.Deserialize(reader);
            }
            return data;
        }

        //Takes path to an XML file and loads a level
        public void Load(String XMLFileName)
        {
            //load each
            for(int i = 0; i < rooms.Count; i++)
            {
                rooms[i].Load();
            }
        }
        public void Update(GameTime gameTime)
        {

        }
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
