using System;

class TicTacToe
{
    static char[,] board = new char[3, 3];
    static char currentPlayer = 'X';

    static void Main(string[] args)
    {
        InitializeBoard();
        PlayGame();
    }

    static void InitializeBoard()
    {
        for (int i = 0; i < 3; i++)
            for (int j = 0; j < 3; j++)
                board[i, j] = ' ';
    }

    static void PlayGame()
    {
        bool gameEnded = false;
        do
        {
            Console.Clear();
            PrintBoard();
            TakeTurn();
            gameEnded = CheckForWinner() || CheckForTie();
            if (!gameEnded) SwitchPlayer();
        } while (!gameEnded);

        Console.Clear();
        PrintBoard();
        if (CheckForWinner())
        {
            Console.WriteLine($"Parabéns, jogador {currentPlayer} ganhou!");
        }
        else
        {
            Console.WriteLine("Empate!");
        }
    }

    static void PrintBoard()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Console.Write(board[i, j]);
                if (j < 2) Console.Write(" | ");
            }
            Console.WriteLine();
            if (i < 2) Console.WriteLine("---------");
        }
    }

    static void TakeTurn()
    {
        Console.WriteLine($"Vez do jogador {currentPlayer}. Escolha linha e coluna (0, 1, 2):");
        int row = int.Parse(Console.ReadLine());
        int col = int.Parse(Console.ReadLine());

        if (board[row, col] == ' ')
            board[row, col] = currentPlayer;
        else
        {
            Console.WriteLine("Essa posição já está ocupada. Tente novamente.");
            TakeTurn();
        }
    }

    static bool CheckForWinner()
    {
        for (int i = 0; i < 3; i++)
        {
            if (board[i, 0] != ' ' && board[i, 0] == board[i, 1] && board[i, 1] == board[i, 2])
                return true;
            if (board[0, i] != ' ' && board[0, i] == board[1, i] && board[1, i] == board[2, i])
                return true;
        }

        if (board[0, 0] != ' ' && board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2])
            return true;
        if (board[0, 2] != ' ' && board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0])
            return true;

        return false;
    }

    static bool CheckForTie()
    {
        for (int i = 0; i < 3; i++)
            for (int j = 0; j < 3; j++)
                if (board[i, j] == ' ')
                    return false;
        return true;
    }

    static void SwitchPlayer()
    {
        currentPlayer = currentPlayer == 'X' ? 'O' : 'X';
    }
}