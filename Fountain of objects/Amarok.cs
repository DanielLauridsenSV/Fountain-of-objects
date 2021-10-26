using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fountain_of_objects
{
    public class Amarok
    {
        Position Amarokposition { get; set; }
        private Random random = new Random();
        public Amarok(Gridmap map,Player player)
        {
            Amarokposition = new Position(random.Next(0,map._height),random.Next(0,map._width));
            while (Amarokposition == player.Startingposition || 
                map.Grid[Amarokposition.UpDown, Amarokposition.RightLeft].GetType() ==typeof(Fountain))
            {
                Amarokposition.UpDown =(random.Next(0, map._height));
                Amarokposition.RightLeft = (random.Next(0, map._width));
            }

        }
        public void Amarokmovement(Gridmap map)
        {
            map.Grid[Amarokposition.UpDown, Amarokposition.RightLeft].containsAmarok = false;
           
            if (random.Next(0, 2)==1)
            {
                Amarokposition.UpDown = Amarokposition.UpDown + random.Next(-2, 2);
            }
            else
            {
                Amarokposition.RightLeft = Amarokposition.RightLeft + random.Next(-2, 2);
            }
            map.Grid[Amarokposition.UpDown, Amarokposition.RightLeft].containsAmarok =true;
        }
    }
}
