using System;

namespace Fountain_of_objects
{
    class Empty_Room : Room
    {
        public Empty_Room()
        {
            _Message = "An empty room";
            _Isoccupied = false;
            _Isrevealed = false;
        }

        public override bool Enterroom(Gridmap map, Player player)
        {
            Console.WriteLine("this is an empty room, there is nothing here of interest");
            return false;
        }
    }
}

