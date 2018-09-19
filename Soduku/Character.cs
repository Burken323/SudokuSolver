using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soduku
{
    class Character : Room
    {
        //Det karaktären har på sig;
        public Dictionary<string, string> inventory = new Dictionary<string, string>();
        public string direction;
        

        public void get(string item)
        {
            //Plocka upp objekt och lägg till inventory.
            inventory.Add(item,item);
        }

        public void drop(string item)
        {
            //Släpp objektet i rummet. Lägg tillbaks i rummet.
            inventory.Remove(item);
            AddItem(item, direction);
        }

        public string interact(string key)
        {
            //Hur spelaren ska interacta med objektet.
            return descriptions[key];
        }
    }
}
