using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fountain_of_objects
{
    /// <summary>
    /// Interface for rooms with special properties such as Maelstrom or Hole
    /// </summary>
    public interface IDanger
    {
        public  string WarningMessage();
    }
}
