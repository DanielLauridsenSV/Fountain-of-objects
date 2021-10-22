using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fountain_of_objects
{
    public class Hole : Room
    {
        bool fall = true;
        public Hole()
        {
            message = "hole";
            isoccupied = true;
        }
    }
}
