using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fountain_of_objects
{
    public class Player
    {
       public int PlacementUD { get; set; } = 4;
       public int PlacementRL { get; set; } = 2;

        public void Chosedirection()
        {
            bool possiblemove = false;
            Console.WriteLine(" choose your path with the arrowkeys");
            while (possiblemove == false)
            {
                ConsoleKey movement = Console.ReadKey().Key;
                switch (movement)
                {
                    case ConsoleKey.UpArrow:
                        {
                            if (PlacementUD - 1 >= 0)
                            {
                                PlacementUD--;
                                possiblemove = true;
                                break;
                            }
                            else
                            {
                                Console.WriteLine(" you did not not press a valid key, try again");
                                break;
                            }
                        }
                    case ConsoleKey.DownArrow:
                        {
                            if (PlacementUD + 1 <= 4)
                            {
                                PlacementUD++;
                                possiblemove = true;
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                    case ConsoleKey.LeftArrow:
                        {
                            if (PlacementRL - 1 >= 0)
                            {
                                PlacementRL--;
                                possiblemove = true;
                                break;
                            }
                            else
                            {
                                break; 
                            }
                        }
                    case ConsoleKey.RightArrow:
                        {
                            if (PlacementRL + 1 <= 4)
                            {
                                PlacementRL++;
                                possiblemove = true;
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                }
            }
        }

    }
}

