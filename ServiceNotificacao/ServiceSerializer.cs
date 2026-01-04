using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace ServiceNotification
{
    public class ServiceSerializer
    {
        public void Serializer(DTO.AnalisarPausas pausas)
        {
            var serializer = new XmlSerializer(typeof(DTO.AnalisarPausas));
            using (var writer = XmlWriter.Create("analisePausas.xml"))
                serializer.Serialize(writer, pausas);
        }

        public DTO.AnalisarPausas Deserializer()
        {
            DTO.AnalisarPausas objects;
            using (var reader = new StreamReader("analisePausas.xml"))
            {
                XmlSerializer deserializer = new XmlSerializer(typeof(DTO.AnalisarPausas));
                objects = (DTO.AnalisarPausas)deserializer.Deserialize(reader);
            }

            return objects;
        }

        public void Serializer<T>(T obj, string nome_obj)
        {
            var serializer = new XmlSerializer(typeof(T));
            using (var writer = XmlWriter.Create(nome_obj + ".xml"))
                serializer.Serialize(writer, obj);
        }

        public T Deserializer<T>(string nome_obj)
        {
            T objects;
            using (var reader = new StreamReader(nome_obj + ".xml"))
            {
                XmlSerializer deserializer = new XmlSerializer(typeof(T));
                objects = (T)deserializer.Deserialize(reader);
            }

            return objects;
        }

        public bool ExisteArquivo()
        {
            FileInfo file = new FileInfo("analisePausas.xml");

            if (file.Exists)
            {
                if (file.CreationTime.Date != DateTime.Now.Date)
                {
                    file.Delete();
                    return false;
                }

            }
            else
                return false;

            return true;
        }
    }
}
