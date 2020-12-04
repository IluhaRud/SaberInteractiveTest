using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SaberInteractiveTest
{
    class ListRandom
    {
        public ListNode head;
        public ListNode tail;
        public int count;

        Random rand = new Random();
        public ListNode[] listNodes;

        public ListRandom(int count)
        {
            this.count = count;
            listNodes = new ListNode[count];
            
            for (int i = 0; i < count; i++)
            {
                if (i == 0)
                {
                    head = listNodes[i];
                    listNodes[i] = new ListNode(SetRandomData());
                    continue;
                }

                if (i == listNodes.Length - 1)
                    tail = listNodes[i];

                listNodes[i] = new ListNode(SetRandomData());
                listNodes[i].previous = listNodes[i - 1];
                listNodes[i - 1].next = listNodes[i];
            }
        }
        public ListRandom(ListNode head, ListNode tail, ListNode[] listNodes)
        {
            this.head = head;
            this.tail = tail;
            this.listNodes = listNodes;
        }

        public string SetRandomData()
        {
            string[] names = new string[]
            {
                "Илья",
                "Антон",
                "Андрей",
                "Валентин",
                "Анастасия",
                "Александра",
                "Пётр",
                "Марина",
                "Константин"
            };

            return names[rand.Next(0, names.Length)];
        }

        public void Serialize()
        {
            XElement doublyLinkedList = new XElement("DOUBLY_LINKED_LIST");

            for (int i = 0; i < listNodes.Length; i++)
            {
                XAttribute myData = new XAttribute("MyData", listNodes[i].data);
                XAttribute previousData = new XAttribute("PreviousData", (listNodes[i].previous == null ? "null" : listNodes[i].previous.data));
                XAttribute nextData = new XAttribute("NextData", (listNodes[i].next == null ? "null" : listNodes[i].next.data));

                XElement element = new XElement($"ELEMENT_{i}");
                element.Add(myData, previousData, nextData);
                doublyLinkedList.Add(element);
            }

            doublyLinkedList.Save("Elements.xml");
        }
        static public ListRandom Deserialize(string path)
        {
            StreamReader stream = new StreamReader(path);
            string xmlDoc = stream.ReadToEnd();
            ListNode[] listNodes;

            List<XElement> elements = XDocument.Parse(xmlDoc).Root.Elements().ToList();

            listNodes = new ListNode[elements.Count];

            for (int i = 0; i < elements.Count; i++)
            {
                if (i == 0)
                {
                    listNodes[i] = new ListNode(elements[i].Attribute("MyData").Value);
                    continue;
                }

                listNodes[i] = new ListNode(elements[i].Attribute("MyData").Value);
                listNodes[i].previous = listNodes[i - 1];
                listNodes[i - 1].next = listNodes[i];
            }

            return new ListRandom(listNodes[0], listNodes[listNodes.Length - 1], listNodes);
        }
    }
}
