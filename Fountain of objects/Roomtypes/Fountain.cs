using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fountain_of_objects
{
    public class Fountain : Room
    {
        bool Win = false;
        public Fountain()
        {
            message = "fountain";
            isoccupied = true;
        }
        //public override void RoomActivation()
        //{
        //    Console.WriteLine("you have found the fountain, but it seems deactivated and empty. \n in the room you find a button, do you want to press it?" +
        //        "Y/N");
        //    if (Console.ReadLine().Equals("y",StringComparison.OrdinalIgnoreCase))
        //    {
        //        Win = true;
        //    }
        //    else
        //    {
        //        Console.WriteLine("you leave the button unklicked and continue to another Room");
        //    }
        }
    }
//}
