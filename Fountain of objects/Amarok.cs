using System;

namespace Fountain_of_objects
{
    /// <summary>
    ///  the Amarok is a wandering Enemy, it works like the player class and is not a roomtype. If the player encounters the Amarok the game is over,
    /// </summary>
    public class Amarok : IDanger
    {
        public Position Position { get; set; }
        public string Message = " you smeel the stench of the Amarok in the room, It attacks you from the shadows and eat you";

        private Random _random = new Random();
        public Amarok(Gridmap map, Player player)
        {
            Position = new Position(_random.Next(0, map.Height), _random.Next(0, map.Width));

            while (Position == player.StartingPosition ||
                map.GridRoom(Position).GetType() == typeof(Fountain))
            {
                Position.UpDown = (_random.Next(0, map.Height));
                Position.RightLeft = (_random.Next(0, map.Width));
            }
        }
        public void AmarokMovement(Gridmap map)

        {
            int height = map.Height;
            int width = map.Width;
            map.GridRoom(Position).ContainsAmarok = false;

            Position movement = new Position(0, 0);
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
                    newPos.RightLeft < 0 || newPos.RightLeft >= width)
                {
                    movement.UpDown = 0;
                    movement.RightLeft = 0;
                    continue;
                }
                else
                {
                    map.GridRoom(newPos).ContainsAmarok = true;
                    Position = newPos;
                    break;
                }

            }
        }

        public string WarningMessage()
        {
            string msg = "you smell the foul stench of the Amarok, there is an Amarok in one of the adjacent rooms";
            return msg;
        }
    }
}
