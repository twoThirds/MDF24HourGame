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

        List<Room> rooms;
        Room currentRoom;
        Vector2 scroll;
        Player player;
        String XMLFileName;
        Game1 game;

        public Level()
        {
            rooms = new List<Room>();
            player = new Player();
        }

		public void Initialize(String XMLFileName, Player player, Game1 game)
		{
			this.player = player;
			player.Initialize(game);
			this.game = game;
			scroll = new Vector2(0, 0);
			Load(XMLFileName);
			rooms.Add(new Room());
			int i;
			for (i = 0; i < rooms.Count; i++)
			{
				rooms[i].Initialize(game);
			}
			//load each room
			currentRoom = rooms[0];
			rooms[0].SetActive(player);

		}
        //Takes path to an XML file and loads a level
        public void Load(String XMLFileName)
		{
			this.XMLFileName = XMLFileName;
            // comment this line after first time run
            //createXMLfileTemplate(rooms, XMLFileName);
            //load stuff
            //DeSerilize(rooms, XMLFileName);

        }


        public void Update(GameTime gameTime)
        {
            //update each room
            int i;
            for (i = 0; i < rooms.Count; i++)
            {
                //GAME OVER
                //If the player is dead reset the game
                if(rooms[i].Update(gameTime, scroll))
                {
                    player.Reset();
                    Load(XMLFileName);
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

        public void createXMLfileTemplate<T>(T data, string filepath)
        {
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
                xmlSerializer.Serialize(writer, data, ns);
            }
        }

        public T DeSerilize<T>(T _data, string filePath)
        {
            XmlSerializer ser = new XmlSerializer(_data.GetType());

            using (XmlReader reader = XmlReader.Create(filePath))
            {
                _data = (T)ser.Deserialize(reader);
            }
            return _data;
        }

    }
}
