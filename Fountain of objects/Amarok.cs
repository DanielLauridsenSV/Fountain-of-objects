using System;

namespace Fountain_of_objects
{
    /// <summary>
    ///  the Amarok is a wandering Enemy, it works like the player class and is not a roomtype. If the player encounters the Amarok the game is over,
    /// </summary>
    public class Amarok
    {
        public Position Position { get; set; }
        public static string Message = "* you smeel the stench of the Amarok," +
                                       " There is an Amarok in on of the Adjacent Rooms";

        private Random _random = new Random();
        public Amarok(Gridmap map, Player player)
        {
            int height = map.Height;
            int width = map.Width;
            Position = new Position(_random.Next(0, height), _random.Next(0, width));

            while (Position == player.StartingPosition 
                || map.Grid.GetRoom(Position).GetType() == typeof(Fountain))
            {
                Position.UpDown = (_random.Next(0, height));
                Position.RightLeft = (_random.Next(0, width));
            }
        }
        public void Move(Gridmap map)
        {
            int height = map.Height;
            int width = map.Width;
            map.Grid.GetRoom(Position).ContainsAmarok = false;

            Position movement = new (0, 0);
            while (true)
            {
                int key = _random.Next(0, 4);

                switch (key)
                {
                    case 0:
                        {
                            movement = new Position(0, -1); break;
                        }
                    case 1:
                        {
                            movement = new Position(0, 1); break;
                        }
                    case 2:
                        {
                            movement = new Position(-1, 0); break;
                        }
                    case 3:
                        {
                            movement = new Position(1, 0); break;
                        }
                    default:
                        {
                            break;
                        }
                }
                Position newPos = new Position(Position.UpDown + movement.UpDown,
                                               Position.RightLeft + movement.RightLeft);

                if (newPos.UpDown < 0 || newPos.UpDown >= height ||
                    newPos.RightLeft < 0 || newPos.RightLeft >= width
                    )
                {

                    movement.UpDown = 0;
                    movement.RightLeft = 0;
                    continue;
                }
                else
                {
                    map.Grid.GetRoom(newPos).ContainsAmarok = true;
                    Position = newPos;
                    break;
                }
            }
        }
    }
}
