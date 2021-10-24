﻿using System;
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
        private readonly int _numberOfHoles  = 7;
        private readonly int _numberOfFountains = 1;
        Random rand = new();

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
        private void Placement(Type eventype, int amount)
        {
            int dimension1 = rand.Next(0, _height);
            int dimension2 = rand.Next(0, _width);
            for (int i = 0; i < amount; i++)
            {
                while (Grid[dimension1, dimension2]._Isoccupied)
                {
                    dimension1 = rand.Next(0, 5);
                    dimension2 = rand.Next(0, 5);
                }
                Grid[dimension1, dimension2] = (Room)Activator.CreateInstance(eventype);
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
                    if (Grid[i, j]._Isrevealed == true)
                    {
                        if (position.UpDown == i && position.RightLeft == j)
                        {
                            Console.BackgroundColor = ConsoleColor.DarkBlue;
                            Console.Write($"{Grid[i, j]._Message,-13}");
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.Write("|");
                        }
                        else
                        {
                            Console.Write($"{Grid[i, j]._Message,-13}|");
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
        public void MakePositionVisible(playerposition location) => Grid[location.UpDown, location.RightLeft]._Isrevealed = true;
        private void CreateEntrypoint(playerposition location) => Grid[location.UpDown, location.RightLeft] = new Entryroom();
    }
}

