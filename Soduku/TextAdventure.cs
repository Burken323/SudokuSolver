using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soduku
{
    class TextAdventure
    {
        //Skapar lista med alla rum, samt karaktär.
        public List<Room> Rooms = new List<Room>();
        public Character character = new Character();

        public List<Room> RoomInitializer()
        {
            //Skapa rummen med objekt osv.
            return Rooms;
        }

        public void Navigation()
        {
            //character.direction
         
        }

        public void Play()
        {
            //Kollar med navigation vart man står, fortsätter spelet utefter det.
            //Navigation();
        }
    }
}
