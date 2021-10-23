using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fountain_of_objects
{

    public class Gridmap
    {
        public Room[,] grid { get; set; }
        public int Height { get; set; } = 5;
        private int Width { get; set; } = 5;
        int NumberOfHoles { get; set; } = 7;
        int NumberOfFountains { get; set; } = 1;
        Random rand = new();
     
        public Gridmap(playerturn logs)
        {
            CreateGrid();
            CreateEntrypoint(logs);
            placement(typeof(Fountain) , NumberOfFountains);
            placement(typeof(Hole), NumberOfHoles);
        }
        private void CreateGrid()
        {
            grid = new Room[Height, Width];
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    grid[i, j] = new Empty_Room();
                }
            }
        }
        private void CreateEntrypoint(playerturn firstturn)
        {
            grid[firstturn.updown,firstturn.rightleft] = new Entryroom();
        }
        private void placement(Type eventype,int amount)
        {
            int dimension1 = rand.Next(0, 5);
            int dimension2 = rand.Next(0, 5);
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
        public void Visualizemap(List<playerturn> logs)
        {
            playerturn currentposition = logs.Last();
            Isvisible(logs);

            Console.Write($"{"______________________________________________________________________"}\n");
            for (int i = 0; i < Height; i++)
            {      
                for (int j = 0; j < Width; j++)
                 {
                    if (grid[i, j].Isrevealed == true)
                    {
                        if (currentposition.updown ==i && currentposition.rightleft ==j)
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
        public void Isvisible(List<playerturn> logs)
        {
            for (int i = 0; i < logs.Count; i++)
            {
                grid[logs[i].updown, logs[i].rightleft].Isrevealed = true;
            }
        }
        public void enterRoom(Player player)
        {
            grid[player.Logger.Last().rightleft, player.Logger.Last().updown].Isrevealed = true;
        }

    }
}

