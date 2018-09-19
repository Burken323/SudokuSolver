using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soduku
{
    class Room : TextAdventure
    {
        //Lista med objekt som finns i rum.
        public Dictionary<string, Dictionary<string, string>> objectsDirection;
        public Dictionary<string, string> objectsNorth;
        public Dictionary<string, string> objectsEast;
        public Dictionary<string, string> objectsWest;
        public Dictionary<string, string> objectsSouth;
        public Dictionary<string, string> descriptions;



        public void setObjectsAfterDirection()
        {
            objectsDirection.Add("NORTH", objectsNorth);
            objectsDirection.Add("EAST", objectsEast);
            objectsDirection.Add("WEST", objectsWest);
            objectsDirection.Add("SOUTH", objectsSouth);
            
            
        } 

        public string inspect(string key)
        {
            //Kontrollera andra ordet. Beroende på det så blir det olika förklaringar.
            
            return descriptions[key];

        }

        public void AddItem(string item, string direction)
        {
            var checkDirection = objectsDirection[direction];
            checkDirection.Add(item, item);

        }

        public void look()
        {
            //Skriv ut allt i rummet.

            foreach( var key in descriptions )
            {
                Console.WriteLine(descriptions[key.Key]);
            }
        }

        public Dictionary<string, string> setDescription(Dictionary<string, string> descriptions)
        {
            descriptions.Add("KEY", "A key is used to open something that's locked.");
            descriptions.Add("EAST", "The wall is white.");
            descriptions.Add("WEST", "The wall is white1.");
            descriptions.Add("NORTH", "The wall is white2.");
            descriptions.Add("SOUTH", "The wall is white.3");


            return descriptions;
        }
    }
}
