using System;
using System.Threading;

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
                map.VisualizeMap(player.Location);
                player.Chosedirection();
                Console.Clear(); 
                map.VisualizeMap(player.Location);
                if (map.grid[player.Location.UpDown, player.Location.RightLeft].Enterroom(map, player))
                {
                    break;
                }
                supportclass.Sleep();
            }
            supportclass.Sleep();
        }

    }
}

