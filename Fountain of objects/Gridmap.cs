using System;
using System.Collections.Generic;
using System.Linq;

namespace Fountain_of_objects
{
    /// <summary>
    /// gridmap is the labyrinth in which the game is played. most properties are only used for configuration
    /// </summary>
    public class Gridmap
    {
        public RoomsGrid Grid;
        public int Height { get; set; }
        public int Width { get; set; }
        private int _numberOfHoles;
        private int _numberOfFountains;
        private int _numberOfMaelstroms;
        public int NumberOfAmaroks { get; set; }
        private Random _rand = new();

        /// <summary>
        /// create the map and places objects on the map. 
        /// </summary>
        /// <param name="player"></param>
        public Gridmap(int height, int width)
        {
            Height = height;
            Width = width;
            _numberOfHoles=(int)(height * 1.2);
            _numberOfFountains = 1;
            _numberOfMaelstroms = (int)(height / 2.5);
            NumberOfAmaroks = (int)(Height * 0.3);
        }
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
            Grid = new RoomsGrid(new Position(Height, Width));

            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    Grid.Addvalue(new Position(i, j), new Empty_Room());
                }
            }
        }
        /// <summary>
        /// places objects on the gridmap
        /// </summary>
        /// <param name="eventType"></param>
        /// <param name="amount"></param>
        private void Placement(Type eventType, int amount)
        {
            Position position = new(0, 0);
            position.UpDown = _rand.Next(0, Height);
            position.RightLeft = _rand.Next(0, Width);
            for (int i = 0; i < amount; i++)
            {
                while (Grid.GetRoom(position).IsOccupied)
                {
                    position.UpDown = _rand.Next(0, Height);
                    position.RightLeft = _rand.Next(0, Width);
                }
                Grid.Addvalue(position, (Room)Activator.CreateInstance(eventType));
            }
        }
        /// <summary>
        /// Visualization of the gridmap where player position is highlighted
        /// </summary>
        /// <param name="location"></param>
        public void VisualizeMap(Position location)
        {
            MakePositionVisible(location);
            string lines = "";
            for (int i = 0; i < Width; i++) lines += "______________";
           

            Console.Write($"{lines}\n");
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    if (Grid.GetRoom(new Position(i, j)).IsRevealed == true)
                    {
                        if (location.UpDown == i && location.RightLeft == j)
                        {
                            Console.BackgroundColor = ConsoleColor.DarkBlue;
                            Console.Write($"{Grid.GetRoom(location).Message,-13}");
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.Write("|");
                        }
                        else
                        {
                            Console.Write($"{Grid.GetRoom(new Position(i, j)).Message,-13}|");
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
        /// tells the player if the adjacent room(all 8 directions) contain a specialroom or Amarok
        /// </summary>
        /// <param name="playerposition"></param>
        /// <param name="Amarok"></param>
        public void SenseDanger(Position playerposition)
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
                if (Grid.GetRoom(pos) is IDanger)
                {
                    IDanger danger = (IDanger)Grid.GetRoom(pos);
                    msg.Add(danger.WarningMessage());


                }
                else if (Grid.GetRoom(pos).ContainsAmarok)
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
        public void MakePositionVisible(Position location) => Grid.GetRoom(location).IsRevealed = true;
        /// <summary>
        /// creates the entryroom at specified location.
        /// </summary>
        /// <param name="location"></param>
        private void CreateEntrypoint(Position location)
        {
            Grid.Addvalue(location, new Entryroom());

        }
        //}

        /// </summary>
        /// <param name="playerposition"></param>
    }
}


