
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Security;
using System.Text;

namespace LifeGame
{
    class Grid
    {

        private int _n;

        public int n
        {
            get { return _n; }
            set { _n = value; }
        }

        private Cell[,] tabCells;

        public Grid(int nbCells, List<Coords> AliveCellsCoords)
        {
            n = nbCells;
            tabCells = new Cell[n, n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Coords checker = new Coords(i, j);
                    foreach (Coords entry in AliveCellsCoords)
                    {
                        if (entry.Equals(checker)) { tabCells[i, j] = new Cell(true); break; }
                        else { tabCells[i, j] = new Cell(false); }
                    }
                }
            }

        }

        public int GetNbAliveNeighboor(int i, int j)
        {
            int number = 0;

            for (int a = -1; a < 2; a++)
            {
                for (int b = -1; b < 2; b++)
                {
                    if (a==0 && b == 0) { continue; }

                    else if (i+a >=n || j+b >=n || i+a<0 || j+b<0) { continue; }

                    else if (tabCells[i+a,j+b]._isAlive) { number++; }

                    else { continue; }
                }
            }

            return number;
        }

        public List<Coords> GetCoordsCellsAlive()
        {
            List<Coords> coordsCellsAlive = new List<Coords>();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (tabCells[i,j]._isAlive) { coordsCellsAlive.Add(new Coords(i, j)); }
                }
            }


            return coordsCellsAlive;
        }

        public void DisplayGrid()
        {
            Console.Clear();
            for (int i = 0; i < n; i++)
            {
                Console.Write("+---");
            }

            Console.Write("+\n");

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write("| {0} ", tabCells[i, j]._isAlive ? "X" : " ");
                }

                Console.Write("|\n");
                for (int j = 0; j < n; j++)
                {
                    Console.Write("+---");
                }
                Console.Write("+\n");

            }
            
        }

        public void UpdateGrid()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (tabCells[i, j]._isAlive == false) 
                    { 
                        if (GetNbAliveNeighboor(i, j) == 3) 
                        { 
                            tabCells[i, j].ComeAlive(); 
                        } 
                    }

                    else if (GetNbAliveNeighboor(i,j)==2 || GetNbAliveNeighboor(i, j) == 3) { tabCells[i, j].ComeAlive(); }

                    else { tabCells[i, j].PassAway(); }
                }
            }
            foreach(Cell entry in tabCells)
            {
                entry.Update();
            }
        }
    }
}
