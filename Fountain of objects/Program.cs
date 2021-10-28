using System;

namespace Fountain_of_objects
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Player player = new();
            Gridmap map = new();
            map.ResetMap(player);
            Amarok amarok = new (map, player);
            Console.WriteLine("welcome to the labyrinth of the fountain.\n\nyou play the game by walking around in the maze looking for the fountain. " +
                "\nbut, with in the Maze there are holes, Maelstromportals and the Deadly Amarok.\nyour senses will tell you if you are near any dangers.");
            Console.WriteLine("you use the Arrowkeys to move");
            Console.WriteLine("press enter to start the game");
            Console.ReadLine();
         
            while (true)
            {
                Console.Clear();
                map.VisualizeMap(player.Location);
                map.SenseDanger(player.Location,amarok);
                player.ChoseDirection(map);
                Console.Clear(); 
                map.VisualizeMap(player.Location);
                amarok.AmarokMovement(map);
                if (map.Grid.GetRoom(player.Location).EnterRoom(map, player))
                {
                    break;
                }
                if (map.Grid.GetRoom(player.Location).ContainsAmarok)
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

