using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Xml;

namespace ProtoGTFS.Common
{
    public static class Config
    {
        private static readonly string pathGTFSDefine = Assembly.GetExecutingAssembly().Location + ".config";
        
        private static readonly string pathRouteMaster = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\例外系統設定マスタ.txt";

        public static List<GTFSDefineFileNode> configGTFSDefine;

        public static RouteMaster configRouteMaster;

        public static void Read()
        {
            ReadRouteMaster();
            ReadGTFSDefine();
        }

        private static void ReadGTFSDefine()
        {
            var xmlDocument = new XmlDocument();
            xmlDocument.Load(pathGTFSDefine);
            configGTFSDefine = new List<GTFSDefineFileNode>();

            XmlElement root = xmlDocument.DocumentElement;
            XmlNodeList nodes = root.SelectNodes("//GTFSFile");

            foreach (XmlNode node in nodes)
            {
                var fileNode = new GTFSDefineFileNode();
                fileNode.Name = node.Attributes["name"].Value;
                foreach (XmlNode n in node)
                {
                    var fieldNode = new GTFSDefineFieldNode();
                    fieldNode.Order = n.Attributes["order"].Value;
                    fieldNode.Name = n.Attributes["name"].Value;
                    fieldNode.Tag = n.Attributes["tag"].Value;
                    fileNode.AddChildNode(fieldNode);
                }
                configGTFSDefine.Add(fileNode);
            }
        }

        private static void ReadRouteMaster()
        {
            configRouteMaster = new RouteMaster();
            foreach (var textLine in File.ReadAllLines(pathRouteMaster))
            {
                var text = textLine.Split(',');
                var routeConfig = new RouteConfig();
                routeConfig.RouteId = text[0];
                routeConfig.PrinterMode = text[1];
                routeConfig.ICSupport = text[2];
                configRouteMaster.Add(routeConfig);
            }
        }
    }

    public class GTFSDefineFileNode : IEnumerable<GTFSDefineFieldNode>
    {
        private List<GTFSDefineFieldNode> childNodes;

        public GTFSDefineFileNode()
        {
            this.childNodes = new List<GTFSDefineFieldNode>();
        }

        public string Name { get; set; }


        public void AddChildNode(GTFSDefineFieldNode node)
        {
            this.childNodes.Add(node);
        }

        public GTFSDefineFieldNode Find(string name)
        {
            return childNodes.Find(node => node.Name == name);
        }

        public IEnumerator<GTFSDefineFieldNode> GetEnumerator()
        {
            return childNodes.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return childNodes.GetEnumerator();
        }
    }

    public class GTFSDefineFieldNode
    {
        public string Order { get; set; }

        public string Name { get; set; }

        public string Tag { get; set; }
    }

    public class RouteMaster : IEnumerable<RouteConfig>
    {
        private List<RouteConfig> list;

        public RouteMaster()
        {
            this.list = new List<RouteConfig>();
        }

        public void Add(RouteConfig route)
        {
            this.list.Add(route);
        }

        public RouteConfig? Get(string id)
        {
            foreach (var item in list)
            {
                if (item.RouteId == id)
                {
                    return item;
                }
            }
            return null;
        }

        IEnumerator<RouteConfig> IEnumerable<RouteConfig>.GetEnumerator()
        {
            return this.list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.list.GetEnumerator();
        }
    }

    public class RouteConfig
    {
        public string RouteId { get; set; }

        public string PrinterMode { get; set; }

        public string ICSupport { get; set; }
    }
}
