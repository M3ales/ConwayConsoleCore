using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLifeConsole
{
    public class Game
    {
        public Game(long xSize, long ySize)
        {
            currentTick = new Grid(xSize, ySize);
        }

        public Game(Grid grid)
        {
            currentTick = grid;
        }

        public Grid currentTick;

        public Grid Tick()
        {
            Grid next = new Grid(currentTick.XBoundry + 1, currentTick.YBoundry + 1);
            next = MergedRuleset(next, currentTick);
            return next;
        }

        public void Simulate()
        {
            currentTick = Tick();
        }
        /// <summary>
        /// Applies underpop, overpop, survival and reproduction steps in one tick set.
        /// </summary>
        /// <param name="next"></param>
        /// <param name="current"></param>
        /// <returns></returns>
        public Grid MergedRuleset(Grid next, Grid current)
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
