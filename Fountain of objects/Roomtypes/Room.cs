namespace Fountain_of_objects
{
    public abstract class Room
    {
        public string _Message;
        public bool _Isoccupied = false;
        public bool _Isrevealed = false;
        public bool _fountainactivated = false;

        public abstract bool Enterroom(Gridmap map, Player player);
    }
}
