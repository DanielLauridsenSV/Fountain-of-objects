namespace Fountain_of_objects
{
    public abstract class Room
    {
        public string _message;
        public bool _isOccupied = false;
        public bool _isRevealed = false;
        public bool _fountainActivated = false;
        public bool containsAmarok = false;

        public abstract bool EnterRoom(Gridmap map, Player player);
    }
}
