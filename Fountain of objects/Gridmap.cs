using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fountain_of_objects
{

    public class Gridmap
    {
        public Room[,] grid { get; private set; }
        private int _height  = 5;
        private int _width  = 5;
        private int _numberOfHoles  = 7;
        private int _numberOfFountains = 1;
        Random rand = new();

        private void CreateGrid()
        {
            grid = new Room[_height, _width];
            for (int i = 0; i < _height; i++)
            {
                for (int j = 0; j < _width; j++)
                {
                    grid[i, j] = new Empty_Room();
                }
            }
        }
        private void Placement(Type eventype, int amount)
        {
            int dimension1 = rand.Next(0, _height);
            int dimension2 = rand.Next(0, _width);
            for (int i = 0; i < amount; i++)
            {
                while (grid[dimension1, dimension2].isoccupied)
                {
                    dimension1 = rand.Next(0, 5);
                    dimension2 = rand.Next(0, 5);
                }
                grid[dimension1, dimension2] = (Room)Activator.CreateInstance(eventype);
            }
        }
        public void VisualizeMap(playerposition position)
        {

            MakePositionVisible(position);
            string lines = ("______________________________________________________________________");
            Console.Write($"{lines}\n");
            for (int i = 0; i < _height; i++)
            {
                for (int j = 0; j < _width; j++)
                {
                    if (grid[i, j].Isrevealed == true)
                    {
                        if (position.UpDown == i && position.RightLeft == j)
                        {
                            Console.BackgroundColor = ConsoleColor.DarkBlue;
                            Console.Write($"{grid[i, j].message,-13}");
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.Write("|");
                        }
                        else
                        {
                            Console.Write($"{grid[i, j].message,-13}|");
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
        public void Resetmap(Player player)
        {
            CreateGrid();
            CreateEntrypoint(player.Startingposition);
            Placement(typeof(Fountain), _numberOfFountains);
            Placement(typeof(Hole), _numberOfHoles);
        }
        public void MakePositionVisible(playerposition position) => grid[position.UpDown, position.RightLeft].Isrevealed = true;
        private void CreateEntrypoint(playerposition firstturn) => grid[firstturn.UpDown, firstturn.RightLeft] = new Entryroom();
    }
}

