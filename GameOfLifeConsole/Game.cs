using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLifeConsole
{
    /// <summary>
    /// Performs Game Logic (and Rules) on Grid instances.
    /// </summary>
    public class Game
    {
        /// <summary>
        /// Produces a game with an empty grid of the given size.
        /// </summary>
        /// <param name="xSize">X size of the playing space</param>
        /// <param name="ySize">Y size of the playing space</param>
        public Game(long xSize, long ySize)
        {
            CurrentTick = new Grid(xSize, ySize);
        }
        /// <summary>
        /// Produces a game with a given grid.
        /// </summary>
        /// <param name="grid"></param>
        public Game(Grid grid)
        {
            CurrentTick = grid;
        }

        public Grid CurrentTick { get; private set; }

        /// <summary>
        /// Applies the ruleset on the currentTick's grid, and produces a result. Current Tick is Immutable.
        /// </summary>
        /// <returns></returns>
        public Grid Tick()
        {
            Grid next = new Grid(CurrentTick.XBoundry + 1, CurrentTick.YBoundry + 1);
            next = ApplyRuleset(next, CurrentTick);
            return next;
        }

        public void Simulate()
        {
            CurrentTick = Tick();
        }

        /// <summary>
        /// Applies underpop, overpop, survival and reproduction steps in one tick set.
        /// </summary>
        /// <param name="next"></param>
        /// <param name="current"></param>
        /// <returns></returns>
        protected Grid ApplyRuleset(Grid next, Grid current)
        {
            for (int i = 0; i <= current.XBoundry; i++)
            {
                for (int j = 0; j <= current.YBoundry; j++)
                {
                    int alive = current.AliveNeighbours(i, j);
                    if (current.Cells[i, j] == Cell.Alive)
                    {
                        if (alive < 2)
                        {
                            //underpopulation
                            next.Cells[i, j] = Cell.Dead;
                        }else if (alive > 3)
                        {
                            //overpopulation
                            next.Cells[i, j] = Cell.Dead;
                        }else
                        {
                            //survival
                            next.Cells[i, j] = Cell.Alive;
                        }
                    }
                    else
                    {
                        //reproduction
                        if (alive == 3)
                        {
                            next.Cells[i, j] = Cell.Alive;
                        }
                    }
                }
            }
            return next;
        }
    }
}
