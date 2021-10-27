using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Fountain_of_objects
{
    /// <summary>
    /// gridmap is the labyrinth in which the game is played. most properties are only used for configuration
    /// </summary>
    public class Gridmap
    {
        public Room[,] Grid { get; set; }
        public int Height { get; set; } = 5;
        public int Width { get; set; } = 5;
        private int _numberOfHoles = 6;
        private int _numberOfFountains = 1;
        private int _numberOfMaelstroms = 2;
        public int _numberOfAmaroks = 1;
        private Random _rand = new();

        /// <summary>
        /// create the map and places objects on the map. 
        /// </summary>
        /// <param name="player"></param>
        public void ResetMap(Player player)
        {
            CreateGrid();
            CreateEntrypoint(player.StartingPosition);
            Placement(typeof(Fountain), _numberOfFountains);
            Placement(typeof(Hole), _numberOfHoles);
            Placement(typeof(Maelstrom), _numberOfMaelstroms);
        }
        /// <summary>
        ///creates the gridmap on which the game is played.
        /// </summary>
        private void CreateGrid()
        {
            Grid = new Room[Height, Width];
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
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
            Position position = new(0, 0);
            position.UpDown = rand.Next(0, Height);
            position.RightLeft = rand.Next(0, Width);
            for (int i = 0; i < amount; i++)
            {
                while (GridRoom(position).IsOccupied)
                {
                    position.UpDown = rand.Next(0, 5);
                    position.RightLeft = rand.Next(0, 5);
                }
                Grid[position.UpDown,position.RightLeft] = (Room)Activator.CreateInstance(eventType);
            }
        }
        /// <summary>
        /// Visualization of the gridmap where player position is highlighted
        /// </summary>
        /// <param name="location"></param>
        public void VisualizeMap(Position location)
        {
            MakePositionVisible(location);
            string lines = ("______________________________________________________________________");
            Console.Write($"{lines}\n");
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    if (Grid[i, j].IsRevealed == true)
                    {
                        if (location.UpDown == i && location.RightLeft == j)
                        {
                            Console.BackgroundColor = ConsoleColor.DarkBlue;
                            Console.Write($"{Grid[i, j].Message,-13}");
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.Write("|");
                        }
                        else
                        {
                            Console.Write($"{Grid[i, j].Message,-13}|");
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

        public void SenseDanger(Position playerposition, Amarok Amarok)
        {
            int width = Width;
            int height = Height;
            List<Position> toSearch = new()
            {
                new Position(1, 0),
                new Position(-1, 0),
                new Position(0, 1),
                new Position(0, -1),
                new Position(1, 1),
                new Position(-1, -1),
                new Position(1, -1),
                new Position(-1, 1)
            };
            List<String> msg = new();
            foreach (Position p in toSearch)
            {
                Position pos = new Position(playerposition.UpDown + p.UpDown,
                                            playerposition.RightLeft + p.RightLeft);
                if (pos.UpDown < 0 || pos.UpDown >= height ||
                    pos.RightLeft < 0 || pos.RightLeft >= width)
                {
                    continue;
                }
                if (GridRoom(pos) is IDanger)
                {
                    IDanger danger = (IDanger)GridRoom(pos);
                     msg.Add(danger.WarningMessage());


                }
                else if (GridRoom(pos).ContainsAmarok)
                {
                     msg.Add(Amarok.WarningMessage());
                } 
            }
            foreach (var item in msg.Distinct())
            {
                Console.WriteLine($"*{item}");
            }
        }

        /// <summary>
        /// makes the room at players position revealed and thus able to display message
        /// </summary>
        /// <param name="location"></param>
        public void MakePositionVisible(Position location) => GridRoom(location).IsRevealed = true;
        /// <summary>
        /// creates the entryroom at specified location.
        /// </summary>
        /// <param name="location"></param>
        private void CreateEntrypoint(Position location) => Grid[location.UpDown,location.RightLeft] =new Entryroom();
        
        /// </summary>
        /// <param name="playerposition"></param>
        public Room GridRoom(Position Position) => Grid[Position.UpDown, Position.RightLeft];
    }
}


