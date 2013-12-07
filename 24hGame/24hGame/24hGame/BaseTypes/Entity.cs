using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;
using System.Xml;
namespace _24hGame.BaseTypes
{
    public class Entity
    {
        public void Serialize<Entity>(Entity data, string filePath)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Entity));
            //Overridden to use UTF8 for compatability with Perl XML::DOM

            using (TextWriter writer = new StreamWriter(filePath))
            {
                xmlSerializer.Serialize(writer, data);
            }
        }

        public Entity DeSerilize(Entity data, string filePath)
        {
            XmlSerializer ser = new XmlSerializer(typeof(Entity));

            using (XmlReader reader = XmlReader.Create(filePath))
            {
                data = (Entity)ser.Deserialize(reader);
            }
            return data;
        }
    }
    
}
