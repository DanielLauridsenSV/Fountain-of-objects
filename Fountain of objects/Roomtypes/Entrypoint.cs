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
        public override void RoomActivation()
        {
            Console.WriteLine("you are near the labyrints entrypoint and you can feel the cool breeze from the enterance;");
        }
    }
}
