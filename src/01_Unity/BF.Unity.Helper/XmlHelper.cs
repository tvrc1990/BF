using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace BF.Unity.Helper
{

    public class XmlHelper
    {
        private static XmlDocument xmlDoc = new XmlDocument();

        public static bool Insert(string xmlFilePath, string nodeName, string nodeText, string parentNamespace = "")
        {
            Execute(xmlFilePath, new Action(() =>
            {

                var element = xmlDoc.CreateElement(nodeName);
                element.InnerText = nodeText;
                var xmlNode = xmlDoc.SelectSingleNode(parentNamespace);
                xmlNode.AppendChild(element);
                xmlDoc.Save(xmlFilePath);
            }));
            return true;
        }
        public static bool Insert(string xmlFilePath, string elementName, string attrValue, string attrName = "", string parentNamespace = "")
        {
            Execute(xmlFilePath, new Action(() =>
            {
                var element = xmlDoc.CreateElement(elementName);
                element.SetAttribute(string.IsNullOrWhiteSpace(attrName) ? elementName : attrName, attrValue);
                var xmlNode = xmlDoc.SelectSingleNode(parentNamespace);
                xmlNode.AppendChild(element);
                xmlDoc.Save(xmlFilePath);
            }));
            return true;
        }
        public static bool UpdateText(string xmlFilePath, string nodeText, string namespaceUri = "")
        {
            Execute(xmlFilePath, new Action(() =>
               {
                   var xmlNode = xmlDoc.SelectSingleNode(namespaceUri);
                   xmlNode.InnerText = nodeText;
                   xmlDoc.Save(xmlFilePath);
               }));
            return true;

        }

        public static bool UpdateAttribute(string xmlFilePath, string attributeName, string value, string namespaceUri = "")
        {
            Execute(xmlFilePath, new Action(() =>
            {
                var xmlElement = (XmlElement)xmlDoc.SelectSingleNode(namespaceUri);
                xmlElement.SetAttribute(attributeName, value);
                xmlDoc.Save(xmlFilePath);
            }));
            return true;

        }

        public static bool Delete(string xmlFilePath, string namespaceUri)
        {
            Execute(xmlFilePath,
                new Action(() =>
                {
                    var xmlNode = xmlDoc.SelectSingleNode(namespaceUri);
                    xmlNode.ParentNode.RemoveChild(xmlNode);
                    xmlDoc.Save(xmlFilePath);
                }));

            return true;
        }

        public static List<string> GetElementValues(string xmlFilePath, string namespaceUri, string attributeName = "")
        {

            var result = new List<string>();
            Execute(xmlFilePath,
              new Action(() =>
              {
                  var xmlNodes = xmlDoc.SelectNodes(namespaceUri);
                  foreach (XmlNode node in xmlNodes)
                  {
                      if (string.IsNullOrWhiteSpace(attributeName))
                          result.Add(node.InnerText);
                      else
                          result.Add(((XmlElement)node).GetAttribute(attributeName));
                  }
              }));

            return result;
        }

        private static void Execute(string xmlFilePath, Action func)
        {
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.IgnoreComments = true;//忽略文档里面的注释

            using (XmlReader reader = XmlReader.Create(xmlFilePath, settings))
            {
                xmlDoc.Load(reader);
            }
            func.Invoke();

        }

    }
}