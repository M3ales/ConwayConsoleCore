using System;

namespace GameOfLifeConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Grid grid = new Grid(35, 35);
            //space ship (by mistake)
            grid.Cells[20, 20] = Cell.Alive;
            grid.Cells[20, 21] = Cell.Alive;
            grid.Cells[21, 20] = Cell.Alive;
            grid.Cells[22, 20] = Cell.Alive;
            grid.Cells[22, 22] = Cell.Alive;
            //thingy that does pattern over and over, no move
            grid.Cells[10, 10] = Cell.Alive;
            grid.Cells[11, 10] = Cell.Alive;
            grid.Cells[12, 10] = Cell.Alive;
            grid.Cells[13, 10] = Cell.Alive;
            grid.Cells[13, 11] = Cell.Alive;
            Game g = new Game(grid);
            for(int i = 0; i < 100; i++)
            {
                g.Simulate();
                Console.WriteLine();
                Console.WriteLine(i + "\r\n"+ g.currentTick);
            }
            Console.Read();
        }
    }
}
