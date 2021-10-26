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
            random.Next(0, 1);
        }
    }
}
