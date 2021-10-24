using System;
using System.Threading;

namespace Fountain_of_objects
{
    static class supportclass
    {
        /// <summary>
        /// used instead of console.Readkey to make play more intuitive
        /// </summary>
        public static void Sleep()
        {
            string dots = (".....");
            for (int i = 0; i < dots.Length; i++)
            {
                Console.Write(dots[i]);
                Thread.Sleep(230);
            }
        }
    }
}
