using LifeGame;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace JeuDeLaVie
{
    class Game
    {
        private int n;
        private int iter;
        public Grid grid;
        private readonly List<Coords> AliveCellsCoords;

        public Game(int nbCells, int nbIterations)
        {
            n = nbCells;
            iter = nbIterations;
            AliveCellsCoords = new List<Coords> {
                new Coords(5, 5),
                new Coords(5, 4),
                new Coords(5, 6),
                new Coords(4, 5),
                new Coords(6, 5)
            };
            grid = new Grid(n, AliveCellsCoords);
        }

        public void RunGameConsole()
        {
            grid.DisplayGrid();
            for (int i = 0; i < iter; i++)
            {
                Thread.Sleep(60);
                grid.UpdateGrid();
                grid.DisplayGrid();

            }
        }

    }
}
