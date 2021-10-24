using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fountain_of_objects
{
    public class Hole : Room
    {
        
        public Hole()
        {
            message = "hole";
            isoccupied = true;
        }

        public override bool Enterroom(Gridmap map,Player player)
        {
            
            Console.WriteLine("you fell in a hole and lost all progress");
            map.Resetmap(player);
            player.Location.RightLeft = player.Startingposition.RightLeft;
            player.Location.UpDown = player.Startingposition.UpDown;
            Console.ReadKey();
            return false;
        }
    }
}
