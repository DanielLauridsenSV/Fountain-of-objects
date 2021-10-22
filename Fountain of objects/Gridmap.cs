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
                    grid[i, j] = new Room();
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
            for (int i = 0; i < logs.Count; i++)
            {
                grid[logs[i].updown, logs[i].rightleft].Isrevealed = true;
            }
        
        
            int firstdimention = grid.GetLength(0);
            int seconddimention = grid.GetLength(1);
            Console.Write($"{"_________________________________________________________________"}\n");
            for (int i = 0; i < firstdimention; i++)
            {      
                for (int j = 0; j < seconddimention; j++)
                 {
                    if (grid[i, j].Isrevealed == true)
                    {
                            Console.Write($"{grid[i, j].message,-12}|");   
                    }
                    else
                    {
                        Console.Write($"{"",-12}|");
                    }

                }
                Console.Write($"\n{"_________________________________________________________________"}\n");
            }
        }
        public void enterRoom(Player player)
        {
            grid[player.Logger.Last().rightleft, player.Logger.Last().updown].Isrevealed = true;
        }

    }
}

