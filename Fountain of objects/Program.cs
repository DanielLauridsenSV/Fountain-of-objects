using System;
using System.Collections.Generic;

namespace Fountain_of_objects
{
    class Program
    {
        static void Main(string[] args)
        {
            Player player = new();
            Gridmap map = new(player.location);
            while (true)
            {
                Console.Clear();
                map.Visualizemap(player.location);
                Room roomType = map.grid[player.location.UpDown, player.location.RightLeft];
                string roomEvent = map.roomevent(roomType);
                if (EventChecker(map, player, roomEvent))
                {
                    break;
                };
                Console.Clear();
                map.Visualizemap(player.location);
                player.Chosedirection();

            }
        }
        public static bool EventChecker(Gridmap map, Player player, string roomEvent)
        {

            if (roomEvent.Equals("Hole", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("you fell in a hole and lost all progress");
                map.Resetmap(player);
                player.location.RightLeft = player.startingposition.RightLeft;
                player.location.UpDown = player.startingposition.UpDown;
                Console.ReadKey();
                return false;

            }
            else if (roomEvent.Equals("fountain", StringComparison.OrdinalIgnoreCase))
            {
                map.grid[player.location.UpDown, player.location.RightLeft].Enterroom();

            }
            if (map.grid[player.location.UpDown, player.location.RightLeft].fountainactivated)
            {
                Console.WriteLine(" you leave the labyrinth with the wisdom of the fountain");
                Console.ReadKey();
                return true;
            }
            return false;
        }

    }
}

