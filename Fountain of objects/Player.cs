using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fountain_of_objects
{
    public class Player
    {
        public playerposition Startingposition { get;init; } = new(4, 2);
        public playerposition Location { get; set; }
        public  List<playerposition> Logger { get; set; }
        public Player()
        {
            Location = new(Startingposition.UpDown,Startingposition.RightLeft);
            Logger = new();
            Logger.Add(Location);
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
                            if (Location.UpDown- 1 >= 0)
                            {
                                Location.UpDown = Location.UpDown -1;
                                Logger.Add(new playerposition(Location));
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
                            if (Location.UpDown + 1 <= 4)
                            {
                                Location.UpDown = Location.UpDown +1;
                                Logger.Add( new playerposition(Location));
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
                            if (Location.RightLeft - 1 >= 0)
                            {
                                Location.RightLeft = Location.RightLeft -1;
                                Logger.Add(new playerposition(Location));
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
                            if (Location.RightLeft + 1 <= 4)
                            {
                                Location.RightLeft = Location.RightLeft+1;
                                Logger.Add(new playerposition(Location));
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

