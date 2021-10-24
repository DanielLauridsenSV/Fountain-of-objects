using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fountain_of_objects
{
    public class Fountain : Room
    {
        public Fountain()
        {
            message = "fountain";
            isoccupied = true;
        }
        public override bool Enterroom(Gridmap map,Player player)
        {
           
            Console.WriteLine("you found the fountain, but it seems deactivated and empty. You found a button. It is big and red, do you want to press it?Y/N");
            if (Console.ReadLine().Equals("Y", StringComparison.OrdinalIgnoreCase))
            {
                fountainactivated = true;
                Console.WriteLine("you press the button and the fountain lights up. you know the fountain have been activated");
                return true;
            }
            return false;
        }
    }
}
