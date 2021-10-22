using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fountain_of_objects
{
    public class Player
    {
        public playerturn location;
        public  List<playerturn> Logger { get; set; }
        public Player()
        {
            location = new(4, 2);
            Logger = new();
            Logger.Add(location);
        }
        public void DisplayPosition()
        {
            Console.WriteLine($"you are currently at {location.updown+1} from the top and {location.rightleft+1} from the left");
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
                            if (location.updown- 1 >= 0)
                            {
                                location.updown = location.updown --;
                                Logger.Add(location);
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
                            if (location.updown + 1 <= 4)
                            {
                                location.updown = location.updown ++;
                                Logger.Add(location);
                                possiblemove = true;
                                break;
                            }
                            else
                            {
                                Console.WriteLine(" you did not not press a valid key, try again");
                                break;
                            }
                        }
                    case ConsoleKey.LeftArrow:
                        {
                            if (location.rightleft - 1 >= 0)
                            {
                                location.rightleft = location.rightleft --;
                                Logger.Add(location);
                                possiblemove = true;
                                break;
                            }
                            else
                            {
                                Console.WriteLine(" you did not not press a valid key, try again");
                                break;
                            }
                        }
                    case ConsoleKey.RightArrow:
                        {
                            if (location.rightleft + 1 <= 4)
                            {
                                location.rightleft = location.rightleft++;
                                Logger.Add(location);
                                possiblemove = true;
                                break;
                            }
                            else
                            {
                                Console.WriteLine(" you did not not press a valid key, try again");
                                break;
                            }
                        }
                }
            }
        }

    }
}

