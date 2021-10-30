namespace Fountain_of_objects
{
    /// <summary>
    ///  class used to track playerposition in two dimensions
    /// </summary>
    public class Position
    {
        public int UpDown { get; set; }
        public int RightLeft { get; set; }

        public Position(int updownValue, int rightLeftValue)
        {
            UpDown = updownValue;
            RightLeft = rightLeftValue;
        }
        public Position(Position position)
        {
            UpDown = position.UpDown;
            RightLeft = position.RightLeft;
        }
    }
}