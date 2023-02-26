
class Map
{
    public int Y = Console.WindowHeight / 2;
    public int X = Console.WindowWidth / 2;
    public int[,] map = new int[Console.WindowHeight / 2 - 2, Console.WindowHeight / 2 - 2];
    public int[,] snakeheadPosition { get; set; }

    public void Board()
    {
        map[1, 1] = 1;
        map[2, 1] = 1;
        map[2, 0] = 1;
        for (int y = 0; y <= Y; y++)
        {
            for (int x = 0; x <= X; x++)
            {
                if (y == 0 || y == Y)
                {
                    Console.Write('-');
                }
                else if(x == 0 || x == X)
                {
                    Console.Write('|');
                }
                else
                {
                    Console.Write(' ');
                }
            }
            Console.WriteLine();
        }
    }

    public void MoveSnake(string direction)
    {
        switch (direction)
        {
            case "UpArrow":
                up();
                    break;
            case "DownArrow":
                down();
                    break;
            case "LeftArrow":
                left();
                    break;
            case "RightArrow":
                right();
                    break;
        }
    }

    public void up()
    {

    }

    public void down()
    {

    }

    public void left()
    {

    }
    public void right()
    {

    }
}