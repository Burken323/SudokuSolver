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
        public Room roomMiddle = new Room();
        public Room roomNorth = new Room();
        public Room roomWest = new Room();
        public Room roomEast = new Room();
        public Room roomSouth = new Room();
        public Dictionary<string, Room> rooms = new Dictionary<string, Room>();
        public Dictionary<string, string> descriptions = new Dictionary<string, string>();
        public Character character = new Character();

        public void RoomInitializer()
        {
            //Skapa startrummet med objekt osv.
            roomMiddle.objects.Add("CANDYBAR", "CANDYBAR");
            roomMiddle.objects.Add("GAMEGUIDE", "GAMEGUIDE");
            roomNorth.objects.Add("KEY", "KEY");
            roomWest.objects.Add("BIRD", "BIRD");
            roomEast.objects.Add("BOTTLE", "BOTTLE");
            roomSouth.objects.Add("DOOR", "DOOR");
            rooms.Add("NORTH", roomNorth);
            rooms.Add("WEST", roomWest);
            rooms.Add("MIDDLE", roomMiddle);
            rooms.Add("EAST", roomEast);
            rooms.Add("SOUTH", roomSouth);
            setDescription();

        }

        public void RoomChange(string direction)
        {
            if (direction.Equals("NORTH") || direction.Equals("SOUTH") || direction.Equals("EAST") || direction.Equals("MIDDLE") || direction.Equals("WEST"))
            {
                //Change room to NORTH
                Navigation(rooms[direction]);
            }
            else
            {
                Console.WriteLine("Invalid command!");
            }
        }
        public void setDescription()
        {
            descriptions.Add("KEY", "A key is used to open something that's locked.");
            descriptions.Add("DOOR", "The wall is white.");
            descriptions.Add("BIRD", "The wall is white1.");
            descriptions.Add("CANDYBAR", "The wall is white2.");
            descriptions.Add("GAMEGUIDE", "The wall is white.3");
            descriptions.Add("BOTTLE", "The wall is white.3");
        }

        public void inspect(string key)
        {
            Console.WriteLine(descriptions[key]);

        }

        public void Navigation(Room room)
        {
            //character.direction
            character.currentRoom = room;
        }

        public void Play()
        {
            //Kollar med navigation vart man står, fortsätter spelet utefter det.
            //Navigation();
            Console.WriteLine("Welcome to PORK. A simple TextAdventure game.");
            Console.WriteLine();
            RoomInitializer();
            bool stillPlaying = true;
            while (stillPlaying)
            {
                string[] input = Console.ReadLine().ToUpper().Split(' ');

                if (input[0].Equals("INSPECT"))
                {
                    //room.inspect(input[1]);
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
                    character.currentRoom.look();
                }
                else if (input[0].Equals("GO"))
                {
                    RoomChange(input[1]);
                }

                Environment.Exit(0);
            }
        }
    }
}
