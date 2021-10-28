using System;

namespace Fountain_of_objects
{
    public class Maelstrom : Room,IDanger
    {
        public Maelstrom()
        {
            Message = "Maelstrom";
            IsOccupied = true;
        }
        public override bool EnterRoom(Gridmap map, Player player)
        {
            IsRevealed = true;
            Console.WriteLine(" you enter the room and find a magical vortex in its center," +
                " do you want to step into it?" +
                "\n Y/N");
            if (Console.ReadLine().Equals("Y", StringComparison.OrdinalIgnoreCase))
            {
              
                Console.WriteLine(" you step into the vortex and is transported to another place on the map");
                player.Location = MaelstromPortal(map);
            }
            else
            {
                Console.WriteLine(" you leave the vortex to someone braver," +
                    " and continue your aimlesswandering though the labyrinth");
            }
            return false;
        }
        public string WarningMessage()
        {
            string msg = "you sense Immense magical power, There is a Maelstrom in one of the adjacent rooms";
                return msg;
        }
        private Position MaelstromPortal(Gridmap map)
        {
            Random random = new Random();
            Position location = new Position(random.Next(0, map.Height), random.Next(0, map.Width));
            while (map.Grid.GetRoom(location).IsOccupied|| map.Grid.GetRoom(location).ContainsAmarok)
            {
                location.UpDown = random.Next(0, map.Height);
                location.RightLeft = random.Next(0, map.Width);
            }
            return new Position(location);
        }
    }
}
