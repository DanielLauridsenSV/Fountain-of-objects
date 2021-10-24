namespace Fountain_of_objects
{
    /// <summary>
    ///  class used to track playerposition in two dimensions
    /// </summary>
    public class playerposition
    {
       public int UpDown { get; set; }
        public int RightLeft { get; set; }

        public playerposition(int updownvalue,int rightleftvalue)
        {
            UpDown = updownvalue;
            RightLeft = rightleftvalue;
        }
        public playerposition(playerposition position)
        {
            UpDown = position.UpDown;
            RightLeft = position.RightLeft;
        }
    }
}