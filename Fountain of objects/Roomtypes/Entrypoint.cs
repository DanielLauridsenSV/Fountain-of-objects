using System;

namespace Fountain_of_objects
{
    public class Entryroom : Room
    {
        public Entryroom()
        {
            _Message = "entry";
            _Isoccupied = true;
            _Isrevealed = true;
        }

        public override bool Enterroom(Gridmap map, Player player)
        {
            Console.WriteLine("the room is near the entrance to the labyrinth, you can feel the warm breeze from outside");
            return false;
        }
    }
}
