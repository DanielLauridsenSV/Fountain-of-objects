using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fountain_of_objects
{
    public class Maelstrom : Room
    {
        public Maelstrom()
        {
            _message = "Maelstrom";
            _isOccupied = true;
        }

        public override bool EnterRoom(Gridmap map, Player player)
        {
            _isRevealed = true;
            Console.WriteLine(" you enter the room and find a magical vortex in its center," +
                " do you want to step into it?" +
                "\n Y/N");
            if (Console.ReadLine().Equals("Y", StringComparison.OrdinalIgnoreCase))
            {
              
                Console.WriteLine(" you step into the vortex and is transported to another place on the map");
                player.Location = Maelstromportal(map);
            }
            else
            {
                Console.WriteLine(" you leave the vortex to someone braver," +
                    " and continue your aimlesswandering though the labyrinth");
            }

            return false;
        }
        private Position Maelstromportal(Gridmap map)
        {
            Position playerposition = supportclass.determineposition(map);
            return playerposition;
        }
    }
}
