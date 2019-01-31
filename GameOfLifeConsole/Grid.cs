using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLifeConsole
{
    public class Grid
    {
        public Grid(long sizeX, long sizeY)
        {
            Cells = new Cell[sizeX, sizeY];
        }
        /// <summary>
        /// Rectangular Array
        /// </summary>
        public Cell[,] Cells { get; private set; }
        /// <summary>
        /// Furthest valid X coordinate
        /// </summary>
        public long XBoundry => Cells.GetLongLength(0) - 1;
        /// <summary>
        /// Furthest valid Y coordinate
        /// </summary>
        public long YBoundry => Cells.GetLongLength(1) - 1;

        public bool ValidCoord(long x, long y)
        {
            return ValidX(x) && ValidY(y);
        }

        protected bool ValidX(long x)
        {
            return x >= 0 && x <= XBoundry;
        }

        protected bool ValidY(long y)
        {
            return y >= 0 && y <= YBoundry;
        }

        /// <summary>
        /// Checks given position's Cell value, returns Cell.Dead if it's out of range.
        /// </summary>
        /// <param name="x">X coord of cell</param>
        /// <param name="y">Y coord of cell</param>
        /// <returns>Value of the Cell, or Dead if coord out of range</returns>
        public Cell CellAt(long x, long y)
        {
            if (!ValidCoord(x, y))
                return Cell.Dead;
            return Cells[x, y];
        }

        public Cell North(long x, long y)
        {
            y--;
            return CellAt(x, y);
        }
        public Cell NorthEast(long x, long y)
        {
            y--;
            x++;
            return CellAt(x, y);
        }

        public Cell East(long x, long y)
        {
            x++;
            return CellAt(x, y);
        }
        
        public Cell SouthEast(long x, long y)
        {
            y++;
            x++;
            return CellAt(x, y);
        }

        public Cell South(long x, long y)
        {
            y++;
            return CellAt(x, y);
        }

        public Cell SouthWest(long x, long y)
        {
            y++;
            x--;
            return CellAt(x, y);
        }

        public Cell West(long x, long y)
        {
            x--;
            return CellAt(x, y);
        }
        
        public Cell NorthWest(long x, long y)
        {
            y--;
            x--;
            return CellAt(x, y);
        }

        public int AliveNeighbours(long x, long y)
        {
            return (int)North(x, y) + 
                (int)NorthEast(x, y) +
                (int)East(x, y) +
                (int)SouthEast(x, y) +
                (int)South(x, y) +
                (int)SouthWest(x, y) + 
                (int)West(x, y) +
                (int)NorthWest(x,y);
        }

        public override string ToString()
        {
            string str = "";
            for (int i = 0; i <= YBoundry; i++)
            {
                for (int j = 0; j <= XBoundry; j++)
                {
                    str += String.Format("{0,3}", (int)CellAt(j, i) == 0 ? "-" : "0");
                }
                str += "\n";
            }
            return str;
        }
    }
}
