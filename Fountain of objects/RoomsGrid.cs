using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fountain_of_objects
{
   public class RoomsGrid
    {
        private Room[,] GridMap { get; set; }

        public RoomsGrid(Position maxvalues)
        { 
            GridMap= new Room[maxvalues.UpDown,maxvalues.RightLeft];
        }

        public void Addvalue(Position location, Room roomtype)
        {
            this.GridMap[location.UpDown,location.RightLeft] = roomtype;
        }
        public Room GetRoom(Position location)
        {
            return GridMap[location.UpDown,location.RightLeft];
        }
        ///Add value method.
        /// SHould have postion and type of room
        /// 
    }
}
