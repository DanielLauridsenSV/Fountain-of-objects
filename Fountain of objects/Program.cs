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
            Amarok amarok = new (map, player);
            while (true)
            {
                Console.Clear();
                map.VisualizeMap(player.Location);
                map.SenseDanger(player.Location,amarok);
                player.ChoseDirection(map);
                Console.Clear(); 
                map.VisualizeMap(player.Location);
                amarok.AmarokMovement(map);
                if (map.Gridroom(player.Location).EnterRoom(map, player))
                {
                    break;
                }
                if (map.Gridroom(player.Location).ContainsAmarok)
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

