using System.IO;
using System.Xml.Serialization;

namespace EJuiceMaker.Data
{
    public sealed class FlavorManager
    {
        public static FlavorCollection Load(string filename)
        {
            using (var stream = new FileStream(filename, FileMode.Open, FileAccess.Read))
            {
                return Load(stream);
            }
        }

        public static FlavorCollection Load(Stream stream)
        {
            var xml = new XmlSerializer(typeof(FlavorCollection), "http://schneenet.com/EJuiceMaker/Inventory.xsd");
            return (FlavorCollection)xml.Deserialize(stream);
        }
    }
}
