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
        public List<string> objects;
        public string lockedDoor;
        public string previousDoor;

        public void inspect()
        {
            //Kontrollera andra ordet. Beroende på det så blir det olika förklaringar.
        }

        public void look()
        {
            //Skriv ut allt i rummet.
        }
    }
}
