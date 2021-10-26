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


        public void Amarokmovement()
        {
           Random random = new Random();
            if (random.Next(0, 2)==1)
            {
                Amarokposition.UpDown = Amarokposition.UpDown + random.Next(-2, 2);
            }
            else
            {
                Amarokposition.RightLeft = Amarokposition.RightLeft + random.Next(-2, 2);
            }

        }
    }
}
