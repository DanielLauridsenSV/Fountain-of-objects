using System;
using System.Threading;

namespace Fountain_of_objects
{
    static class SupportClass
    {
        /// <summary>
        /// used instead of console.Readkey() to make play more intuitive
        /// </summary>
        public static void Sleep(int time = 230)
        {
            string dots = (".....");
            for (int i = 0; i < dots.Length; i++)
            {
                Console.Write(dots[i]);
                Thread.Sleep(time);
            }
        }
        public static Gridmap Choosemap()
        {
            switch (Console.ReadLine())
            {
                case "1":
                    {
                        return new Gridmap(4, 4);
                    }
                case "2":
                    {
                        return new Gridmap(6, 6);
                    }
                case "3":
                    {
                        return new Gridmap(8, 8);
                    }
                default:
                    {
                        return new Gridmap(4, 4);
                    }
            }
        }
    }
}
