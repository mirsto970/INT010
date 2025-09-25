using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace INT0010._4PS.Services.Extensions
{
    public static class XmlDocumentExtensions
    {
        public static T ToClass<T>(this XmlDocument document) where T : class
        {
            var serializer = new XmlSerializer(typeof(T));
            using (MemoryStream ms = new MemoryStream())
            {
                document.Save(ms);
                ms.Seek(0, SeekOrigin.Begin);

                return serializer.Deserialize(ms) as T;
            }
        }

        public static XmlDocument Serialize<T>(this T data) where T : class
        {

            // TODO: Remove. Debug
            /*
            XmlSerializer serializerDebug = new XmlSerializer(typeof(T));
            using (StreamWriter writer = new StreamWriter(@"D:\temp\invoapp_xml_debug.xml"))
            {
                serializerDebug.Serialize(writer, data);
            }
            */


            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (MemoryStream ms = new MemoryStream())
            {
                serializer.Serialize(ms, data);
                ms.Position = 0;

                using (XmlReader xmlReader = XmlReader.Create(ms))
                {
                    XmlDocument document = new XmlDocument();
                    document.Load(xmlReader);
                    return document;
                }
            }
        }

        public static string SerializeToString<T>(this T data, Encoding encoding) where T : class
        {

            XmlSerializer serializer = new XmlSerializer(typeof(T));
            XmlWriterSettings xmlWriterSettings = new XmlWriterSettings
            {
                Indent = true,
                OmitXmlDeclaration = false,
                Encoding = encoding
            };

            using (var stream = new MemoryStream())
            {
                using (var xmlWriter = XmlWriter.Create(stream, xmlWriterSettings))
                {
                    serializer.Serialize(stream, data);
                }
                return encoding.GetString(stream.ToArray());
            }
        }

        public static void AddSpaceToEmptyNodes(this XmlNode node)
        {
            if (node.HasChildNodes)
            {
                foreach (XmlNode child in node.ChildNodes)
                    AddSpaceToEmptyNodes(child);
            }
            else
            {
                try
                {
                    if (node.NodeType == XmlNodeType.Element)
                        node.AppendChild(node.OwnerDocument.CreateTextNode(""));
                }
                catch (InvalidOperationException) { } // This is already a text node


            }

        }

    }
}
