using System;
using System.Collections.Generic;

namespace Fountain_of_objects
{
    public class Player
    {
        public  Position StartingPosition = new(4, 2);
        public Position Location { get; set; }
        public List<Position> Logger { get; set; }
        public Player(int mapsize)
        {
            StartingPosition = new(mapsize - 1, mapsize / 2);
            Location = new(StartingPosition.UpDown, StartingPosition.RightLeft);
            Logger = new();
            Logger.Add(Location);
        }
        /// <summary>
        /// allows player to chose move, and checks if it is a allowed move.
        /// </summary>
        public void ChoseDirection(Gridmap map)
        {
            int width = map.Width;
            int height = map.Height;

            ConsoleKey key = Console.ReadKey().Key;
            Position movement = new Position(0, 0);

            switch (key)
            {
                case ConsoleKey.UpArrow:
                    movement = new Position(-1,0 );
                    break;
                case ConsoleKey.DownArrow:
                    movement = new Position(+1, 0);
                    break;
                case ConsoleKey.LeftArrow:
                    movement = new Position(0, -1);
                    break;
                case ConsoleKey.RightArrow:
                    movement = new Position(0, +1);
                    break;
                default:
                    break;
            }

            Position newPos = new Position(Location.UpDown + movement.UpDown, 
                                           Location.RightLeft + movement.RightLeft);

            if (newPos.UpDown < 0 || newPos.UpDown >= height || 
                newPos.RightLeft < 0 || newPos.RightLeft >= width)
            {
                Console.WriteLine("you cannot move past player the edge of the map");
                return;
            }

            Location = newPos;
            Logger.Add(new Position(Location));
        }
    }
}




