using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fountain_of_objects
{
    public class Entryroom : Room
    {
        public Entryroom()
        {
            message = "entry";
            isoccupied = true;
            Isrevealed = true;
        }

        public override void Enterroom()
        {
            Console.WriteLine("the room is near the entrance to the labyrinth, you can feel the warm breeze from outside");
        }
    }
}
