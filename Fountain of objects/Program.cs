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
                player.DisplayPosition();
                map.Visualizemap(player.location);
                Room Roomtype = map.grid[player.location.updown, player.location.rightleft];
                string roomevent = map.roomevent(Roomtype);
                eventchecker(map, player, roomevent);
                player.Chosedirection();

            }

        }
        public static void eventchecker(Gridmap map, Player player, string roomevent)
        {
            if (roomevent.Equals("Hole", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("you fell in a hole and lost all progress");
                player.location = player.startingposition;
                map.Resetmap();
                Console.ReadKey();

            }
            else if (roomevent.Equals("fountain", StringComparison.OrdinalIgnoreCase))
            {
                map.grid[player.location.updown, player.location.rightleft].Enterroom();
            }
            if (map.grid[player.location.updown, player.location.rightleft].fountainactivated)
            {
                Console.WriteLine(" you leave the labyrinth with the wisdom of the fountain");
                Console.ReadKey();

            }

        }

    }
}

