
class Map
{
    public int Y = Console.WindowHeight / 2;
    public int X = Console.WindowWidth / 2;
    public int snakeLength = 3;
    public int moveCount = 0;
    public int[,] map = new int[Console.WindowHeight / 2 - 2, Console.WindowHeight / 2 - 2];
    public string currentDirection = "right";
    public int headPosX = 1;
    public int headPosY = 1;

    public void Board()
    {
        for (int y = 0; y <= Y; y++)
        {
            for (int x = 0; x <= X; x++)
            {
                if (y == 0 || y == Y)
                {
                    Console.Write('■');
                }
                else if(x == 0 || x == X)
                {
                    Console.Write('■');
                }
                else
                {
                    Console.Write(' ');
                }
            }
            Console.WriteLine();
        }
    }

    public void Move()
    {
        Console.SetCursorPosition(headPosX, headPosY);
        Console.Write(" ");

        switch (currentDirection)
        {
            case "up":
                headPosY -= 1;
                break;
            case "down":
                headPosY += 1;
                break;
            case "left":
                headPosX -= 1;
                break;
            case "right":
                headPosX += 1;
                break;
        }
        Console.SetCursorPosition(headPosX, headPosY);
        Console.Write("■");
    }

    public bool collision()
    {
        if(headPosX <= 0 || headPosX >= X)
        {
            return true;
        }

        if (headPosY <= 0 || headPosY >= Y)
        {
            return true;
        }
        return false;
    }

    public void MoveDirection(string direction)
    {
        Console.SetCursorPosition(headPosX, headPosY);
        switch (direction)
        {
            case "UpArrow":
                currentDirection = "up";
                    break;
            case "DownArrow":
                currentDirection = "down";
                break;
            case "LeftArrow":
                currentDirection = "left";
                break;
            case "RightArrow":
                currentDirection = "right";
                break;
        }
    }
}