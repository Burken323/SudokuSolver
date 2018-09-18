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
        public List<string> inventory;
        public string direction;

        public string foundObject { get { return foundObject; } set { foundObject = value; } } 

        public void get()
        {
            //Plocka upp objekt och lägg till inventory.
        }

        public void drop()
        {
            //Släpp objektet i rummet. Lägg tillbaks i rummet.
        }

        public void interact()
        {
            //Hur spelaren ska interacta med objektet.
        }
    }
}
