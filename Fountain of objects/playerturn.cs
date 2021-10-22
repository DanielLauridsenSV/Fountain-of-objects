namespace Fountain_of_objects
{
    public class playerturn
    {
       public int updown { get; set; }
        public int rightleft { get; set; }
        public playerturn(int updownvalue, int rightleftvalue)
        {
           updown = updownvalue;
            rightleft = rightleftvalue;
        }
    }
}