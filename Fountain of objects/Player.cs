using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fountain_of_objects
{
    public class Player
    {
       public int PlacementUD { get; set; } = 2;
       public int PlacementRL { get; set; } = 1;

        public void Chosedirection()
        {
   
            Console.WriteLine(" choose your path with the arrowkeys");
            ConsoleKey movement = Console.ReadKey().Key;
            switch (movement)
            {
                case ConsoleKey.UpArrow:
                    {
                        PlacementUD--;
                        break;
                    }
                case ConsoleKey.DownArrow:
                    {
                        PlacementUD++;
                        break;
                    }
                case ConsoleKey.LeftArrow:
                    {
                        PlacementRL--;
                        break;
                    }
                case ConsoleKey.RightArrow:
                    {
                        PlacementRL++;
                        break;
                    }
                default:
                    {
                        Console.WriteLine(" you did not not press a valid key, try again");
                        Chosedirection();
                        break;
                    }
            }
        }

    }
}

