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

        public override void Enterroom()
        {
            Console.WriteLine("you fell into a hole, and lost all progress");
        }
    }
}
