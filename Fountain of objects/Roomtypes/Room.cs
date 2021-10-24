﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fountain_of_objects
{
    public abstract class Room
    {
        public string message;
        public bool isoccupied = false;
        public bool Isrevealed = false;
        public bool fountainactivated = false;

        public abstract bool Enterroom(Gridmap map, Player player);
     
    }
}
