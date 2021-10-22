using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fountain_of_objects
{

    public class Gridmap
    {
        public Room[,] grid { get; }
        public int downup { get; set; } = 5;
        private int rigthtleft { get; set; } = 5;
        int holes { get; set; } = 7;
        Random rand = new();
     
        public Gridmap(playerturn logs)
        {
            grid = new Room[downup, rigthtleft];
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    grid[i, j] = new Room();
                }
            }
            CreateEntrypoint(logs);
            placeFountain();
            placeHoles(holes);
        }
        private void CreateEntrypoint(playerturn firstturn)
        {
            grid[firstturn.updown,firstturn.rightleft] = new Entryroom();
        }
        private void placeHoles(int holes)
        {
            int dimension1 = rand.Next(0, 3);
            int dimension2 = rand.Next(0, 3);
            for (int i = 0; i < holes; i++)
            {
                while (grid[dimension1, dimension2].isoccupied)
                {
                    dimension1 = rand.Next(0, 5);
                    dimension2 = rand.Next(0, 5);

                }
                grid[dimension1, dimension2] = new Hole();
            }
        }
        private void placeFountain()
        {
            int dimension1 = rand.Next(0, 5);
            int dimension2 = rand.Next(0, 5);
            while (grid[ dimension1, dimension2].isoccupied)
            {
                dimension1 = rand.Next(0, 5);
                dimension2 = rand.Next(0, 5);
            }
            grid[dimension1, dimension2] = new Fountain();
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
            grid[player.PlacementRL, player.PlacementUD].Isrevealed = true;
        }

    }
}

