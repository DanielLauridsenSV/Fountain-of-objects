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
                map.SenseDanger(player.Location);
                player.Chosedirection();
                Console.Clear(); 
                map.VisualizeMap(player.Location);
                if (map.Grid[player.Location.UpDown, player.Location.RightLeft].EnterRoom(map, player))
                {
                    break;
                }
                if (map.Grid[player.Location.UpDown,player.Location.RightLeft].containsAmarok)
                {
                    Console.WriteLine("you step into the room and smeel the foul stench of the amarok, " +
                        "he lunges at you from the shadows and eat you");
                    break;
                        }
                supportclass.Sleep();
            }
            supportclass.Sleep();
        }

    }
}

