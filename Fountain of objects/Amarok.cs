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
        public Amarok(Gridmap map, Player player)
        {
            Amarokposition = new Position(random.Next(0, map._height), random.Next(0, map._width));
            while (Amarokposition == player.Startingposition ||
                map.Grid[Amarokposition.UpDown, Amarokposition.RightLeft].GetType() == typeof(Fountain))
            {
                Amarokposition.UpDown = (random.Next(0, map._height));
                Amarokposition.RightLeft = (random.Next(0, map._width));
            }

        }
        public void AmarokMovement(Gridmap map)
        {
            map.Grid[Amarokposition.UpDown, Amarokposition.RightLeft].containsAmarok = false;
            int updownorRightleft = random.Next(0, 2);
            if (updownorRightleft == 1)
            {
                int upordown = random.Next(0, 2);

                if (Amarokposition.UpDown < map._height - 1 && upordown > 0)
                {
                    Amarokposition.UpDown++;
                }
                else if (Amarokposition.UpDown == map._height - 1 && upordown > 0)
                {
                    Amarokposition.UpDown--;
                }
                else if (Amarokposition.UpDown == 0 && upordown == 0)
                {
                    Amarokposition.UpDown++;
                }
                else if (Amarokposition.UpDown > 0 && upordown == 0)
                {
                    Amarokposition.UpDown--;
                }

            }
            else
            {
                int Rightorleft = random.Next(0, 2);
                if (Amarokposition.RightLeft < map._width - 1 && Rightorleft > 0)
                {
                    Amarokposition.RightLeft++;
                }
                else if (Amarokposition.RightLeft == map._width - 1 && Rightorleft > 0)
                {
                    Amarokposition.RightLeft--;
                }
                else if (Amarokposition.RightLeft == 0 && Rightorleft == 0)
                {
                    Amarokposition.UpDown++;
                }
                else if (Amarokposition.RightLeft > 0 && Rightorleft == 0)
                {
                    Amarokposition.RightLeft--;
                }

            }
            map.Grid[Amarokposition.UpDown, Amarokposition.RightLeft].containsAmarok = true;
        }
    }
}
