using System;
using System.Collections.Generic;

namespace Fountain_of_objects
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("chose how big you want the map to be\n1. 4x4\n2. 6x6\n3. 8x8");
            Gridmap map = SupportClass.Choosemap();
            Player player = new(map.Width);
            List<Amarok> Amaroklist = new List<Amarok>();
            map.ResetMap(player);
            for (int i = 0; i < map.NumberOfAmaroks; i++)
            {
                Amaroklist.Add(new Amarok(map, player));
            }
            
            Console.WriteLine("welcome to the labyrinth of the fountain.\n\nyou play the game by walking around in the maze looking for the fountain. " +
                "\nbut, with in the Maze there are holes, Maelstromportals and the Deadly Amarok.\nyour senses will tell you if you are near any dangers.");
            Console.WriteLine("you use the Arrowkeys to move");
            Console.WriteLine("press enter to start the game");
            Console.ReadLine();
         
            while (true)
            {
                Console.Clear();
                map.VisualizeMap(player.Location);
                map.SenseDanger(player.Location);
                player.ChoseDirection(map);
                Console.Clear(); 
                map.VisualizeMap(player.Location);
             
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
                foreach (var amarok in Amaroklist)
                {
                    amarok.Move(map);
                }
                SupportClass.Sleep();
            }
            SupportClass.Sleep();
        }

    }
}

