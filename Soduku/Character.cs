using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soduku
{
    class Character
    {
        //Det karaktären har på sig;
        public Dictionary<string, string> inventory = new Dictionary<string, string>();
        public Dictionary<string, string> itemDescription = new Dictionary<string, string>();
        public Room currentRoom = new Room();
        
        public void get(string item)
        {
            //Plocka upp objekt och lägg till inventory.
            inventory.Add(item,item);
            //itemDescription.Add(item, descriptions[item]);
        }

        public void drop(string item)
        {
            //Släpp objektet i rummet. Lägg tillbaks i rummet.
            inventory.Remove(item);
            itemDescription.Remove(item);
            //AddItem(item);
        }

        public void interact(string key)
        {
            //Hur spelaren ska interacta med objektet.
            //return descriptions[key];
        }
    }
}
