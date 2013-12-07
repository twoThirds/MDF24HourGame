using _24hGame.Components.Rooms;
using _24hGame.Drawable.Smart.Destructable.Controlled;
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
        public Vector2 scroll;
        public Player player;
        public Level()
        {
            rooms = new List<Room>();
            currentRoom = new Room();
            player = new Player();
        }

        public void createXMLfileTemplate<T>(T data, string filepath){
            Level lvl = new Level();

            Serialize(data, filepath);
        }


        public void Serialize<T>(T data, string filePath)
        {           
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("", "");

            System.Xml.Serialization.XmlSerializer xmlSerializer =
            new System.Xml.Serialization.XmlSerializer(data.GetType());


            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;    
            settings.OmitXmlDeclaration = true;
            settings.Encoding = Encoding.ASCII;
            using (TextWriter writer = new StreamWriter(filePath))
            {
                xmlSerializer.Serialize(writer,data, ns);
            }
        }

        public T DeSerilize<T>(T data, string filePath)
        {
            XmlSerializer ser = new XmlSerializer(data.GetType());

            using (XmlReader reader = XmlReader.Create(filePath))
            {
                data = (T)ser.Deserialize(reader);
            }
            return data;
        }

        //Takes path to an XML file and loads a level
        public void Load(String XMLFileName, Player player)
        {
            // comment this line after first time run
            createXMLfileTemplate(rooms,XMLFileName);
            
   
            //load stuff
            DeSerilize(rooms, XMLFileName);

        }

        public void Update(GameTime gameTime)
        {
            //update each room
            int i;
            for (i = 0; i < rooms.Count; i++)
            {
                rooms[i].Update(gameTime, scroll);
            }
            player.Update(gameTime);
        }
        public void Draw(GameTime gameTime)
        {
            int i;
            for(i = 0; i < rooms.Count; i++)
            {
                rooms[i].Draw(gameTime, scroll);
            }
            player.Draw(gameTime);
        }
    }
}
