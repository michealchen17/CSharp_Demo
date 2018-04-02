using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
namespace XmlConfig
{
   
    class XmlConfig
    {
        //保持配置文件的路徑
        private static string _xmlPath = @".\config.xml";
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="nodes"></param>
        public static void Write(string value, params string[] nodes)
        {
            XmlDocument xmlDoc = new XmlDocument();
            if (File.Exists(_xmlPath))
            {
                xmlDoc.Load(_xmlPath);
            }
            else
            {
                xmlDoc.LoadXml("<XmlConfig/>");
            }
            XmlNode xmlRoot = xmlDoc.ChildNodes[0];
            string xpath = string.Join("/", nodes);
            XmlNode node = xmlDoc.SelectSingleNode(xpath);
            //新增節點
            if (node == null)
            {
                node = makeXPath(xmlDoc, xmlRoot, xpath);
            }
            node.InnerText = value;
            xmlDoc.Save(_xmlPath);
        }
        /// <summary>
        /// 讀取配置
        /// </summary>
        /// <param name="nodes"></param>
        /// <returns></returns>
        public static string Read(params string[] nodes)
        {
            XmlDocument xmlDoc = new XmlDocument();
            if (File.Exists(_xmlPath) == false)
            {
                return null;
            }
            else
            {
                xmlDoc.Load(_xmlPath);
            }
            string xpath = string.Join("/",nodes);
            XmlNode node = xmlDoc.SelectSingleNode("/XmlConfig/"+xpath);
            if (node == null)
            {
                return null;
            }
            return node.InnerText;
        }
        /// <summary>
        /// 遞歸方式創建節點
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="parent"></param>
        /// <param name="xpath"></param>
        /// <returns></returns>
        private static XmlNode makeXPath(XmlDocument doc, XmlNode parent, string xpath)
        {
            string[] partsOfXPath = xpath.Trim('/').Split('/');
            string nextNodeInXPath = partsOfXPath.First();
            if (string.IsNullOrEmpty(nextNodeInXPath))
            {
                return parent;
            }
            XmlNode node = parent.SelectSingleNode(nextNodeInXPath);
            if (node == null)
            {
                node = parent.AppendChild(doc.CreateElement(nextNodeInXPath));
            }
            string rest = string.Join("/", partsOfXPath.Skip(1).ToArray());
            return makeXPath(doc, node,rest); 
        }
    }
}
