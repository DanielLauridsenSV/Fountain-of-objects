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
        private int _Height  = 5;
        private int _Width  = 5;
        private int _NumberOfHoles  = 7;
        private int NumberOfFountains { get; } = 1;
        Random rand = new();

        public Gridmap(playerposition Firstposition)
        {
            CreateGrid();
            CreateEntrypoint(Firstposition);
            Placement(typeof(Fountain), NumberOfFountains);
            Placement(typeof(Hole), _NumberOfHoles);
        }
        private void CreateGrid()
        {
            grid = new Room[_Height, _Width];
            for (int i = 0; i < _Height; i++)
            {
                for (int j = 0; j < _Width; j++)
                {
                    grid[i, j] = new Empty_Room();
                }
            }
        }
        private void CreateEntrypoint(playerposition firstturn)
        {
            grid[firstturn.UpDown, firstturn.RightLeft] = new Entryroom();
        }
        private void Placement(Type eventype, int amount)
        {
            int dimension1 = rand.Next(0, _Height);
            int dimension2 = rand.Next(0, _Width);
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
        public void Visualizemap(playerposition position)
        {
            
            Isvisible(position);

            Console.Write($"{"______________________________________________________________________"}\n");
            for (int i = 0; i < _Height; i++)
            {
                for (int j = 0; j < _Width; j++)
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
                Console.Write($"\n{"______________________________________________________________________"}\n");
            }
        }
        public void Isvisible(playerposition position)
        {
            grid[position.UpDown, position.RightLeft].Isrevealed = true;
        }
        public string roomevent(Room Roomtype)
        {
                   
              switch (Roomtype)
                {
                    case Entryroom:
                        {
                            return "entry Room";
                          
                        }
                    case Hole:
                        {
                            return "hole";
                           
                        }
                    case Fountain:
                        {
                            return "Fountain";
                           
                        }
                    case Empty_Room:
                        {
                            return "empty room";
                        }
                    default:
                        {
                            return "empty room";
                        }
                }
            
           
        }
        public void Resetmap(Player player)
        {
            CreateGrid();
            CreateEntrypoint(player.startingposition);
            Placement(typeof(Fountain), NumberOfFountains);
            Placement(typeof(Hole), _NumberOfHoles);
        }
    }
}

