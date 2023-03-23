
using System;

class Map
{
    public Random rand = new Random();
    public string appleLocationString = "";
    public bool appleOnMap = false;
    public int Y = 50;
    public int X = 50;
    public int snakeLength = 3;
    public int[,] map = new int[100, 50];
    public string currentDirection = "right";
    public int headPosX = 4;
    public int headPosY = 1;
    public bool initiated = false;

    public List<string> SnakePositions = new List<string>();

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
        Console.ForegroundColor = ConsoleColor.Green;
        if (!appleOnMap)
        {
            CreateApple();
        }

        if (initiated)
        {
            string lastPosString = SnakePositions.First();
            string[] positionsStringArray = lastPosString.Split(" ");
            int[] positions = new int[2];
            positions[0] = int.Parse(positionsStringArray[0]);
            positions[1] = int.Parse(positionsStringArray[1]);
            Console.SetCursorPosition(positions[0], positions[1]);
            Console.Write(" ");

            SnakePositions.Remove(lastPosString);
            for (int i = 0; i < SnakePositions.Count; i++)
            {
                string[] StringArray = SnakePositions.ElementAt(i).Split(" ");
                int[] posArray = new int[2];
                posArray[0] = int.Parse(StringArray[0]);
                posArray[1] = int.Parse(StringArray[1]);

                Console.SetCursorPosition(posArray[0], posArray[1]);
                Console.Write("■");
            }

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
            SnakePositions.Add($"{headPosX} {headPosY}");

            string[] apple = appleLocationString.Split(" ");
            int[] pos = new int[2];
            pos[0] = int.Parse(apple[0]);
            pos[1] = int.Parse(apple[1]);

            if (pos[0] == headPosX && pos[1] == headPosY)
            {
                EatApple();
            }
        }
        else
        {
            
            Console.SetCursorPosition(1, 2);
            Console.Write("■");
            SnakePositions.Add($"1 2");
            Console.SetCursorPosition(1, 3);
            Console.Write("■");
            SnakePositions.Add($"1 3");
            Console.SetCursorPosition(headPosX, headPosY);
            Console.Write("■");
            SnakePositions.Add($"{headPosX} {headPosY}");
            initiated = true;
            
        }
        
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

        int snakeCollisionCount = 0;
        SnakePositions.ForEach(x =>
        {
            if (x == $"{headPosX} {headPosY}")
            {
                snakeCollisionCount++;
            }
        });
        if (snakeCollisionCount == 2)
        {
            return true;
        }
        else
        {
            snakeCollisionCount = 0;
        }

        return false;
    }

    public void MoveDirection(string direction)
    {
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

    public void CreateApple()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        bool validPos = false;
        int posX = rand.Next(1, X - 2);
        int posY = rand.Next(1, Y - 2);

        while (!validPos)
        {
            int updatedCount = 0;

            foreach (var pos in SnakePositions)
            {
                if (pos == $"{posX.ToString()} {posY.ToString()}")
                {
                    posX = rand.Next(1, X - 2);
                    posY = rand.Next(1, Y - 2);
                    updatedCount++;
                }
            }

            if (updatedCount == 0)
            {
                validPos = true;
            }
            
        }
        appleLocationString = $"{posX} {posY}";
        Console.SetCursorPosition(posX, posY);
        Console.Write("*");
        Console.ForegroundColor = ConsoleColor.Green;
        appleOnMap = true;
    }

    public void EatApple()
    {
        string[] firstLocationArray = SnakePositions.ElementAt(0).Split(" ");
        int[] pos = new int[2];
        pos[0] = int.Parse(firstLocationArray[0]);
        pos[1] = int.Parse(firstLocationArray[1]);
        SnakePositions =  SnakePositions.Prepend($"{pos[0]} {pos[1] - 1}").ToList();
        appleOnMap = false;
    }
}