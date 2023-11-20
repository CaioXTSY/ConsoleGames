class SnakeGame
{
    static int boardWidth = 20;
    static int boardHeight = 20;
    static int[] food = new int[2];
    static List<int[]> snake = new List<int[]>();
    static string direction = "RIGHT";
    static bool gameOver = false;

    static void Main()
    {
        InitializeGame();
        while (!gameOver)
        {
            DrawBoard();
            Input();
            Logic();
            Thread.Sleep(200);
        }
        Console.WriteLine("Game Over!");
    }

    static void InitializeGame()
    {
        snake.Add(new int[] { 5, 5 });
        PlaceFood();
    }

    static void DrawBoard()
    {
        Console.Clear();
        for (int y = 0; y < boardHeight; y++)
        {
            for (int x = 0; x < boardWidth; x++)
            {
                if (y == 0 || y == boardHeight - 1 || x == 0 || x == boardWidth - 1)
                    Console.Write("#");
                else if (x == food[0] && y == food[1])
                    Console.Write("*");
                else if (IsSnakePart(x, y))
                    Console.Write("o");
                else
                    Console.Write(" ");
            }
            Console.WriteLine();
        }
    }

    static void Input()
    {
        if (Console.KeyAvailable)
        {
            ConsoleKeyInfo key = Console.ReadKey(true);
            switch (key.Key)
            {
                case ConsoleKey.UpArrow: direction = "UP"; break;
                case ConsoleKey.DownArrow: direction = "DOWN"; break;
                case ConsoleKey.LeftArrow: direction = "LEFT"; break;
                case ConsoleKey.RightArrow: direction = "RIGHT"; break;
            }
        }
    }

    static void Logic()
    {
        int[] head = snake[0];
        int[] newHead = new int[] { head[0], head[1] };

        switch (direction)
        {
            case "UP": newHead[1]--; break;
            case "DOWN": newHead[1]++; break;
            case "LEFT": newHead[0]--; break;
            case "RIGHT": newHead[0]++; break;
        }

        if (newHead[0] == 0 || newHead[1] == 0 || newHead[0] == boardWidth - 1 || newHead[1] == boardHeight - 1 || IsSnakePart(newHead[0], newHead[1]))
        {
            gameOver = true;
            return;
        }

        snake.Insert(0, newHead);

        if (newHead[0] == food[0] && newHead[1] == food[1])
        {
            PlaceFood();
        }
        else
        {
            snake.RemoveAt(snake.Count - 1);
        }
    }

    static void PlaceFood()
    {
        Random random = new Random();
        food[0] = random.Next(1, boardWidth - 1);
        food[1] = random.Next(1, boardHeight - 1);
    }

    static bool IsSnakePart(int x, int y)
    {
        foreach (int[] part in snake)
        {
            if (part[0] == x && part[1] == y)
                return true;
        }
        return false;
    }
}
