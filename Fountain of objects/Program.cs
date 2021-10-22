using System;
using System.Collections.Generic;

namespace Fountain_of_objects
{
    class Program
    {
        static void Main(string[] args)
        {
            Player player = new();
            Gridmap map = new(player.location) ;

            while (true)
            {
                player.DisplayPosition();
                map.Visualizemap(player.Logger);
                player.Chosedirection();
                Console.Clear();
            }

        }
    }
    
}

