using System;
using System.Collections.Generic;

namespace Fountain_of_objects
{
    class Program
    {
        static void Main(string[] args)
        {
            Player player = new();
            Gridmap map = new();
            map.Resetmap(player);
            while (true)
            {
                Console.Clear();
                map.Visualizemap(player.Location);
                //if (EventChecker(map, player)) { break; }
                player.Chosedirection();
                Console.Clear(); 
                map.Visualizemap(player.Location);
                if (map.grid[player.Location.UpDown, player.Location.RightLeft].Enterroom(map, player))
                {break;}  
            }
        }
    }
}

