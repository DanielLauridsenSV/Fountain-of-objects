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
        public int downup { get; set; } = 3;
        private int rigthtleft { get; set; } = 3;
        int holes { get; set; }
        Random rand = new();
     
        public Gridmap()
        {
            grid = new Room[downup, rigthtleft];
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    grid[i, j] = new Room();
                }
            }
            CreateEntrypoint();
            placeFountain();
            placeHoles(holes);
        }
        private void CreateEntrypoint()
        {
            grid[2, 1] = new Entryroom();
        }
        private void placeHoles(int holes)
        {
            int dimension1 = rand.Next(0, 3);
            int dimension2 = rand.Next(0, 3);
            for (int i = 0; i < holes; i++)
            {
                while (grid[dimension1, dimension2].isoccupied)
                {
                    dimension1 = rand.Next(0, 3);
                    dimension2 = rand.Next(0, 3);

                }
                grid[dimension1, dimension2] = new Hole();
            }
        }
        private void placeFountain()
        {
            int dimension1 = rand.Next(0, 3);
            int dimension2 = rand.Next(0, 3);
            while (grid[ dimension1, dimension2].isoccupied)
            {
                dimension1 = rand.Next(0, 3);
                dimension2 = rand.Next(0, 3);
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
            Console.Write($"{"_______________________________________"}\n");
            for (int i = 0; i < firstdimention; i++)
            {      
                for (int j = 0; j < seconddimention; j++)
                 {

                    if (grid[i, j].Isrevealed == true)
                    {
                        Console.Write($"{grid[i,j].message,-12}|");
                    }
                    else
                    {
                        Console.Write($"{"",-12}|");
                    }

                }
                Console.Write($"\n{"_______________________________________"}\n");
            }
        }
        public void enterRoom(Player player)
        {
            grid[player.PlacementRL, player.PlacementUD].Isrevealed = true;
        }

    }
}

