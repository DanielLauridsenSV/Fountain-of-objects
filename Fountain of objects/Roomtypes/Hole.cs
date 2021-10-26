using System;

namespace Fountain_of_objects
{
    public class Hole : Room,IDanger
    {
        public Hole()
        {
            Message = "hole";
            IsOccupied = true;
        }
        /// <summary>
        /// resets game and moves player to entryposition
        /// </summary>
        /// <param name="map"></param>
        /// <param name="player"></param>
        /// <returns></returns>
        public override bool EnterRoom(Gridmap map,Player player)
        {
            
            Console.WriteLine("you fell in a hole and lost all progress");
            map.Resetmap(player);
            Position reset = new(player.Startingposition);
            player.Location = reset;
            return false;
        }
    }
}
