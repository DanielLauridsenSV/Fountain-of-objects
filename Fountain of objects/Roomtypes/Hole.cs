using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fountain_of_objects
{
    public class Hole : Room
    {
        bool fall = false;
        public Hole()
        {
            message = "hole";
            isoccupied = true;
        }

        public override void RoomActivation()
        {
            fall = true;
        }
    }
}
