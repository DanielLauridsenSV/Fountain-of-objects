using System;

namespace Fountain_of_objects
{
    public class Entryroom : Room
    {
        public Entryroom()
        {
            Message = "Entry";
            IsOccupied = true;
            IsRevealed = true;
        }

        public override bool EnterRoom(Gridmap map, Player player)
        {
            Console.WriteLine("the room is near the entrance to the labyrinth, you can feel the warm breeze from outside");
            return false;
        }
    }
}
