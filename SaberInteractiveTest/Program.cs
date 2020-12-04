using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaberInteractiveTest
{
    class Program
    {
        static void Main(string[] args)
        {
            ListRandom randomNamesList = new ListRandom(3);

            for (int i = 0; i < randomNamesList.count; i++)
            {
                Console.WriteLine(randomNamesList.listNodes[i].ToString());
            }

            Console.ReadKey();

            randomNamesList.Serialize();

            randomNamesList = null;
            randomNamesList = ListRandom.Deserialize("Elements.xml");

            for (int i = 0; i < randomNamesList.listNodes.Length; i++)
            {
                Console.WriteLine(randomNamesList.listNodes[i].ToString());
            }

            Console.ReadKey();
        }
    }
}
