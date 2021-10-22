using System;
using System.Collections.Generic;

namespace Fountain_of_objects
{
    class Program
    {
        static void Main(string[] args)
        {
            Gridmap map = new();
            Player player = new();
            List<playerturn> log = new();
            playerturn turn = new playerturn(player.PlacementUD, player.PlacementRL);
            log.Add(turn);
            while (true)
            {
                
                map.Visualizemap(log);
                player.Chosedirection();
                log.Add(turn with { updown =player.PlacementUD, rightleft =player.PlacementRL });
                Console.Clear();
            }

        }
    }
    
}

