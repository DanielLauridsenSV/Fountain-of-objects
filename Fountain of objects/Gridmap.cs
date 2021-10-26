using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fountain_of_objects
{

    public class Gridmap
    {
        public Room[,] Grid { get; set; }
        public readonly int _height = 5;
        public readonly int _width = 5;
        private readonly int _numberOfHoles = 6;
        private readonly int _numberOfFountains = 1;
        private readonly int _numberofmaelstroms = 2;
        private Random rand = new();

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
            Placement(typeof(Maelstrom), _numberofmaelstroms);
        }
        /// <summary>
        ///creates the gridmap on which the game is played.
        /// </summary>
        private void CreateGrid()
        {
            Grid = new Room[_height, _width];
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
            Position position = new(0, 0);
            position.UpDown = rand.Next(0, _height);
            position.RightLeft = rand.Next(0, _width);
            for (int i = 0; i < amount; i++)
            {
                while (Grid[position.UpDown, position.RightLeft]._isOccupied)
                {
                    position.UpDown = rand.Next(0, 5);
                    position.RightLeft = rand.Next(0, 5);
                }
                Grid[position.UpDown, position.RightLeft] = (Room)Activator.CreateInstance(eventType);
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
        public void MakePositionVisible(Position location) => Grid[location.UpDown, location.RightLeft]._isRevealed = true;
        /// <summary>
        /// creates the entryroom and specified location.
        /// </summary>
        /// <param name="location"></param>
        private void CreateEntrypoint(Position location) => Grid[location.UpDown, location.RightLeft] = new Entryroom();
        public void SenseDanger(Position playerposition)
        {
            senseobject(playerposition,typeof(Maelstrom),"you hear a magical sound in one of the nearby room, a Maelstrom is in one of the adjacent rooms");
            senseobject(playerposition, typeof(Hole),"you feel a draft from one of the nearby rooms, one of the adjacent rooms is a hole");
            senseobject(playerposition, typeof(Amarok)," you smeel the stench of the Amarok, There is an Amarok in one of the adjacent rooms");
            
            void senseobject(Position playerposition,Type dangerType,string message)
            {

                if (playerposition.UpDown + 1 <= 4 && Grid[playerposition.UpDown + 1, playerposition.RightLeft].GetType() == dangerType ||
                    playerposition.UpDown - 1 >= 0 && Grid[playerposition.UpDown - 1, playerposition.RightLeft].GetType() == dangerType ||
                    playerposition.RightLeft + 1 <= 4 && Grid[playerposition.UpDown, playerposition.RightLeft + 1].GetType() == dangerType ||
                     playerposition.RightLeft - 1 >= 0 && Grid[playerposition.UpDown, playerposition.RightLeft - 1].GetType() == dangerType)
                {
                    Console.WriteLine(message);
                }

            }
        }
    }
}

