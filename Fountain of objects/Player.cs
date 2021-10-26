using System;
using System.Collections.Generic;

namespace Fountain_of_objects
{
    public class Player
    {
        public readonly Position Startingposition = new(4, 2);
        public Position Location { get; set; }
        public List<Position> Logger { get; set; }
        public Player()
        {
            Location = new(Startingposition.UpDown, Startingposition.RightLeft);
            Logger = new();
            Logger.Add(Location);
        }
        /// <summary>
        /// allows player to chose move, and checks if it is a allowed move.
        /// </summary>
        public void ChoseDirection()
        {

            Console.WriteLine(" choose your path with the arrowkeys");

            ConsoleKey movement = Console.ReadKey().Key;
            switch (movement)
            {
                case ConsoleKey.UpArrow:
                    {
                        if (Location.UpDown - 1 >= 0)
                        {
                            Location.UpDown = Location.UpDown - 1;
                            Logger.Add(new Position(Location));
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
                            Location.UpDown = Location.UpDown + 1;
                            Logger.Add(new Position(Location));
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
                            Location.RightLeft = Location.RightLeft - 1;
                            Logger.Add(new Position(Location));
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
                            Location.RightLeft = Location.RightLeft + 1;
                            Logger.Add(new Position(Location));
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


