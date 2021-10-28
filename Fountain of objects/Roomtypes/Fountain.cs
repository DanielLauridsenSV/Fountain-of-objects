using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fountain_of_objects
{
    public class Fountain : Room
    {
        public bool FountainActivated { get; set; }
        public Fountain()
        {
            Message = "Fountain";
            IsOccupied = true;
        }
        /// <summary>
        /// checks if player wants to activate the portal, if the player accepts the game closes
        /// </summary>
        /// <param name="map"></param>
        /// <param name="player"></param>
        /// <returns></returns>
        public override bool EnterRoom(Gridmap map,Player player)
        {
           
            Console.WriteLine("you found the fountain, but it seems deactivated and empty. You found a button. It is big and red, do you want to press it?\nY/N");
            if (Console.ReadLine().Equals("Y", StringComparison.OrdinalIgnoreCase))
            {
                FountainActivated = true;
                Console.WriteLine("you press the button and the fountain lights up. you know the fountain have been activated");
                Console.WriteLine("you leave the labyrinth content. You found what you set out to do and was victorious against the labyrinth");
                supportclass.Sleep(1000);
                return true;
            }
            return false;
        }
    }
}
