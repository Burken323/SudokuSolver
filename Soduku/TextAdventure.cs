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
        public Room roomOne = new Room();
        public Room roomTwo = new Room();
        public Character character = new Character();

        public void RoomInitializer()
        {

            //Skapa rummen med objekt osv.
            roomOne.setObjectsAfterDirection();
            roomTwo.setObjectsAfterDirection();
            Rooms.Add(roomOne);
            Rooms.Add(roomTwo);
           
        }

        public void Navigation(string direction)
        {
            //character.direction
            character.direction = direction;
        }

        public void Play()
        {
            //Kollar med navigation vart man står, fortsätter spelet utefter det.
            //Navigation();
            RoomInitializer();
            bool stillPlaying = true;
            while (stillPlaying)
            {
                Console.WriteLine("Welcome to the most epic TextAdventure.");
                Console.WriteLine();
                //Console.WriteLine("To get the controlls menu type 'Controlls'");
                Console.WriteLine("You are standing in a room, facing North. To see what's around you type 'look'");
                Console.WriteLine("To look change direction type 'Go east' etc.");
                Console.WriteLine("To interract with objects type 'use', 'inspect', 'drop'.");
                Console.WriteLine("To end the game type 'Exit'.");

                string[] input = Console.ReadLine().ToUpper().Split(' ');

                if (input[0].Equals("INSPECT"))
                {
                    roomOne.inspect(input[1]);
                }
                else if (input[0].Equals("USE"))
                {
                    
                }
                else if (input[0].Equals("GET"))
                {
                    character.get(input[1]);
                }
                else if (input[0].Equals("DROP"))
                {
                    character.drop(input[1]);
                }
                else if (input[0].Equals("LOOK"))
                {
                    roomTwo.look();
                }
                else if (input[0].Equals("GO"))
                {
                    Navigation(input[1]);
                }


            }

        }

        public void PlayRoomOne()
        {
            
        }

    }
}
