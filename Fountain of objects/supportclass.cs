using System;
using System.Threading;

namespace Fountain_of_objects
{
    static class supportclass
    {
        /// <summary>
        /// used instead of console.Readkey to make play more intuitive
        /// </summary>
        public static void Sleep( int time =230)
        {
            string dots = (".....");
            for (int i = 0; i < dots.Length; i++)
            {
                Console.Write(dots[i]);
                Thread.Sleep(time);
            }
        }
        public static Position determineposition(Gridmap map)
        {
            Random random = new Random();
            int dimension1 = random.Next(0, map._height);
            int dimension2 = random.Next(0, map._width);
            while (map.Grid[dimension1, dimension2]._isOccupied)
            {
                dimension1 = random.Next(0, map._height);
                dimension2 = random.Next(0, map._width);
            }
            return new Position(dimension1, dimension2);
        }
    }
}
