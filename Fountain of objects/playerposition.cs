namespace Fountain_of_objects
{
    public class playerposition
    {
       public int updown { get; set; }
        public int rightleft { get; set; }

        public playerposition(int updownvalue,int rightleftvalue)
        {
            updown = updownvalue;
            rightleft = rightleftvalue;
        }
        public playerposition(playerposition position)
        {
            updown = position.updown;
            rightleft = position.rightleft;
        }
    }
}