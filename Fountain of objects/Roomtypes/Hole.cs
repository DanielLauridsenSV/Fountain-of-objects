using System;

namespace Fountain_of_objects
{
    public class Hole : Room
    {
        public Hole()
        {
            _Message = "hole";
            _Isoccupied = true;
        }
        public override bool Enterroom(Gridmap map,Player player)
        {
            
            Console.WriteLine("you fell in a hole and lost all progress");
            map.Resetmap(player);
            playerposition reset = new(player.Startingposition);
            player.Location = reset;
            return false;
        }
    }
}
