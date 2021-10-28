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
            map.ResetMap(player);
            Position reset = new(player.StartingPosition);
            player.Location = reset;
            return false;
        }
        public string WarningMessage()
        {
            string msg = "you hear the a breeze from one of the nearby rooms, there is a hole in one of the adjacent rooms";
                return msg;
        }
    }
}
