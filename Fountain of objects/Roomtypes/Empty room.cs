using System;

namespace Fountain_of_objects
{
    class Empty_Room : Room
    {
        public Empty_Room()
        {
            _message = "An empty room";
            _isOccupied = false;
            _isRevealed = false;
        }

        public override bool EnterRoom(Gridmap map, Player player)
        {
            Console.WriteLine("this is an empty room, there is nothing here of interest");
            return false;
        }
    }
}

