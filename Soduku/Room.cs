using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soduku
{
    class Room
    {
        //Lista med objekt som finns i rum.
        public Dictionary<string, string> objects = new Dictionary<string, string>();
        public Dictionary<string, string> roomDescriptions = new Dictionary<string, string>();

        public void inspectRoom(string key)
        {
            //Kontrollera andra ordet. Beroende på det så blir det olika förklaringar.
            //TextAdventure.inspect(key);

        }

        public void AddItem(string item)
        {
            objects.Add(item, item);
            //roomDescriptions.Add(item, descriptions[item]);

        }

        public void look()
        {
            //Skriv ut allt i rummet.
            /*
            foreach( var key in descriptions )
            {
                Console.WriteLine(roomDescriptions[key.Key]);
            }*/
        }
    }
}
