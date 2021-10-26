using System;

namespace Fountain_of_objects
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Player player = new();
            Gridmap map = new();
            map.Resetmap(player);
            Amarok amarok = new Amarok(map, player);
            while (true)
            {
                Console.Clear();
                map.VisualizeMap(player.Location);
                player.ChoseDirection(map);
                Console.Clear(); 
                map.VisualizeMap(player.Location);
                amarok.AmarokMovement(map);
                if (map.Grid[player.Location.UpDown, player.Location.RightLeft].EnterRoom(map, player))
                {
                    break;
                }
                if (map.Grid[player.Location.UpDown,player.Location.RightLeft].ContainsAmarok)
                {
                    Console.WriteLine("you step into the room and smeel the foul stench of the amarok, " +
                        "he lunges at you from the shadows and eat you");
                    Console.ReadLine();
                    break;
                        }
                supportclass.Sleep();
            }
            supportclass.Sleep();
        }

    }
}

