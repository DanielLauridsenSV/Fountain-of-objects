﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fountain_of_objects
{
    public class Fountain : Room
    {
        bool Win = true;
        public Fountain()
        {
            message = "fountain";
            isoccupied = true;
        }
    }
}
