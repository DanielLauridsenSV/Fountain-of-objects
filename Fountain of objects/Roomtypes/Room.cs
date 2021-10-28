namespace Fountain_of_objects
{
    public abstract class Room
    {
        public string Message;
        public bool IsOccupied = false;
        public bool IsRevealed = false;
        public bool ContainsAmarok = false;
        public abstract bool EnterRoom(Gridmap map, Player player);
    }
}
