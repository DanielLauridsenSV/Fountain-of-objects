using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fountain_of_objects
{
    public class Player
    {
        public playerposition startingposition { get;init; } = new(4, 2);
        public playerposition location { get; set; }
        public  List<playerposition> Logger { get; set; }
        public Player()
        {
            location = new(startingposition.UpDown,startingposition.RightLeft);
            Logger = new();
            Logger.Add(location);
        }
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
                            if (location.UpDown- 1 >= 0)
                            {
                                location.UpDown = location.UpDown -1;
                                Logger.Add(new playerposition(location));
                                possiblemove = true;
                                break;
                            }
                            else
                            {
                                Console.WriteLine("you cannot move past the edge of the map");
                                break;
                            }
                        }
                    case ConsoleKey.DownArrow:
                        {
                            if (location.UpDown + 1 <= 4)
                            {
                                location.UpDown = location.UpDown +1;
                                Logger.Add( new playerposition(location));
                                possiblemove = true;
                                break;
                            }
                            else
                            {
                                Console.WriteLine("you cannot move past the edge of the map");
                                break;
                            }
                        }
                    case ConsoleKey.LeftArrow:
                        {
                            if (location.RightLeft - 1 >= 0)
                            {
                                location.RightLeft = location.RightLeft -1;
                                Logger.Add(new playerposition(location));
                                possiblemove = true;
                                break;
                            }
                            else
                            {
                                Console.WriteLine("you cannot move past the edge of the map");
                                break;
                            }
                        }
                    case ConsoleKey.RightArrow:
                        {
                            if (location.RightLeft + 1 <= 4)
                            {
                                location.RightLeft = location.RightLeft+1;
                                Logger.Add(new playerposition(location));
                                possiblemove = true;
                                break;
                            }
                            else
                            {
                                Console.WriteLine("you cannot move past the edge of the map");
                                break;
                            }
                        }
                }
            }
        }

    }
}

