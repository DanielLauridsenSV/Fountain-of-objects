using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fountain_of_objects
{

    public class Gridmap
    {
        public Room[,] Grid { get; private set; }
        private readonly int _height  = 5;
        private readonly int _width  = 5;
        private readonly int _numberOfHoles  = 6;
        private readonly int _numberOfFountains = 1;
        Random rand = new();

        /// <summary>
        /// create the map and places objects on the map. 
        /// </summary>
        /// <param name="player"></param>
        public void Resetmap(Player player)
        {
            CreateGrid();
            CreateEntrypoint(player.Startingposition);
            Placement(typeof(Fountain), _numberOfFountains);
            Placement(typeof(Hole), _numberOfHoles);
        }
        /// <summary>
        ///creates the gridmap on which the game is played.
        /// </summary>
        private void CreateGrid()
        {
           Grid = new Room [_height, _width];
            for (int i = 0; i < _height; i++)
            {
                for (int j = 0; j < _width; j++)
                {
                    Grid[i, j] = new Empty_Room();
                }
            }
        }
        /// <summary>
        /// places objects in the gridmap
        /// </summary>
        /// <param name="eventType"></param>
        /// <param name="amount"></param>
        private void Placement(Type eventType, int amount)
        {
            int dimension1 = rand.Next(0, _height);
            int dimension2 = rand.Next(0, _width);
            for (int i = 0; i < amount; i++)
            {
                while (Grid[dimension1, dimension2]._isOccupied)
                {
                    dimension1 = rand.Next(0, 5);
                    dimension2 = rand.Next(0, 5);
                }
                Grid[dimension1, dimension2] =(Room)Activator.CreateInstance(eventType);
            }
        }
        /// <summary>
        /// Visualization of the gridmap where player position is highlighted
        /// </summary>
        /// <param name="location"></param>
        public void VisualizeMap(playerposition location)
        {

            MakePositionVisible(location);
            string lines = ("______________________________________________________________________");
            Console.Write($"{lines}\n");
            for (int i = 0; i < _height; i++)
            {
                for (int j = 0; j < _width; j++)
                {
                    if (Grid[i, j]._isRevealed == true)
                    {
                        if (location.UpDown == i && location.RightLeft == j)
                        {
                            Console.BackgroundColor = ConsoleColor.DarkBlue;
                            Console.Write($"{Grid[i, j]._message,-13}");
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.Write("|");
                        }
                        else
                        {
                            Console.Write($"{Grid[i, j]._message,-13}|");
                        }
                    }
                    else
                    {
                        Console.Write($"{"",-13}|");
                    }

                }
                Console.Write($"\n{lines}\n");
            }
        }

        /// <summary>
        /// makes the room at players position revealed and thus able to display message
        /// </summary>
        /// <param name="location"></param>
        public void MakePositionVisible(playerposition location) => Grid[location.UpDown, location.RightLeft]._isRevealed = true;
        /// <summary>
        /// creates the entryroom and specified location.
        /// </summary>
        /// <param name="location"></param>
        private void CreateEntrypoint(playerposition location) => Grid[location.UpDown, location.RightLeft] = new Entryroom();
    }
}

