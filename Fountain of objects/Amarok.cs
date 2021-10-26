using System;


namespace Fountain_of_objects
{
    public class Amarok : IDanger
    {
        public Position Position { get; set; }
        public string Message = " you smeel the stench of the Amarok in the room, It attacks you from the shadows and eat you";

        private Random random = new Random();
        public Amarok(Gridmap map, Player player)
        {
            Position = new Position(random.Next(0, map.Height), random.Next(0, map.Width));
            while (Position == player.Startingposition ||
                map.Grid[Position.UpDown, Position.RightLeft].GetType() == typeof(Fountain))
            {
                Position.UpDown = (random.Next(0, map.Height));
                Position.RightLeft = (random.Next(0, map.Width));
            }
        }
        public void AmarokMovement(Gridmap map)
        {
            int height = map.Height;
            int width = map.Width;

            int key = random.Next(0, 4);
            Position movement = new Position(0, 0);
            while (true)
            {
                switch (key)
                {
                    case 0:
                        {
                            movement = new Position(0, -1);
                            break;
                        }
                    case 1:
                        {
                            movement = new Position(0, 1);
                            break;
                        }
                    case 2:
                        movement = new Position(-1, 0);
                        break;
                    case 3:
                        {
                            movement = new Position(-1, 0);
                            break;
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
                    Console.WriteLine("you cannot move past the edge of the map");
                    return;
                }
            }
        }
    }
}
