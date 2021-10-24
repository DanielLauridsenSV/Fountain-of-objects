using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fountain_of_objects
{
    class Empty_Room:Room
    {
            public Empty_Room()
            {
                message = "An empty room";
                isoccupied = false;
                Isrevealed = false;
            }

        public override bool Enterroom(Gridmap map, Player player)
        {
          
            Console.WriteLine("this is an empty room, there is nothing here of interest");
            return false;
        }
    }
    }

