using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace GameOfLifeConsole
{
    /// <summary>
    /// Immutable representation of the game world.
    /// </summary>
    public class Grid
    {
        /// <summary>
        /// Produces a grid of 
        /// </summary>
        /// <param name="sizeX"></param>
        /// <param name="sizeY"></param>
        public Grid(long sizeX, long sizeY)
        {
            Cells = new Cell[sizeX, sizeY];
        }
        /// <summary>
        /// Rectangular Array, immutable. Represents game world.
        /// </summary>
        public readonly Cell[,] Cells;
        /// <summary>
        /// Furthest valid X coordinate
        /// </summary>
        public long XBoundry => Cells.GetLongLength(0) - 1;
        /// <summary>
        /// Furthest valid Y coordinate
        /// </summary>
        public long YBoundry => Cells.GetLongLength(1) - 1;
        /// <summary>
        /// Determines if a given coord is within the X and Y boundries. (To prevent out of range access on Cells array)
        /// </summary>
        /// <param name="x">X Coord to test</param>
        /// <param name="y">Y Coord to test</param>
        /// <returns>True if the area is within the bounds of the Cells array, False otherwise.</returns>
        public bool ValidCoord(long x, long y)
        {
            return ValidX(x) && ValidY(y);
        }
        /// <summary>
        /// Determines if given X coord is within the range of Cells.
        /// </summary>
        /// <param name="x">Coordinate to check</param>
        /// <returns>True if within range, False if not</returns>
        protected bool ValidX(long x)
        {
            return x >= 0 && x <= XBoundry;
        }

        /// <summary>
        /// Determines if given Y coord is within the range of Cells.
        /// </summary>
        /// <param name="y">Coordinate to check</param>
        /// <returns>True if within range, False if not</returns>
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
        /// <summary>
        /// Sums the Cell values (Alive = 1, Dead = 0) of all Neighbouring Cells (including Diagonals)
        /// </summary>
        /// <param name="x">The Centre Cell X</param>
        /// <param name="y">The Centre Cell Y</param>
        /// <returns>Sum of all adjacent Cells</returns>
        public int AliveNeighbours(long x, long y)
        {
            return (int)North(x, y) +
                (int)NorthEast(x, y) +
                (int)East(x, y) +
                (int)SouthEast(x, y) +
                (int)South(x, y) +
                (int)SouthWest(x, y) +
                (int)West(x, y) +
                (int)NorthWest(x, y);
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
        /// <summary>
        /// Produces a list of dynamics (X, Y) which represents the coordinates of all Cells which are Cell.Alive
        /// </summary>
        /// <returns>A list of dynamics (X, Y) which represents the coordinates of all Cells which are Cell.Alive</returns>
        public IEnumerable<dynamic> GetAliveCells()
        {
            List<dynamic> coords = new List<dynamic>();
            for (int i = 0; i < YBoundry; i++)
                for (int j = 0; j < XBoundry; j++)
                {
                    if (Cells[j, i] == Cell.Alive)
                    {
                        var coord = new
                        {
                            X = j,
                            Y = i
                        };
                        coords.Add(coord);
                    }
                }
            return coords;
        }
    }
}
