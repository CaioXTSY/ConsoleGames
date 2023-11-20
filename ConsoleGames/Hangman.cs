using System;
using System.Collections.Generic;

class HangmanGame
{
    static string[] wordList = { "lobo", "jacare", "capivara", "gato", "domingo" };
    static string chosenWord;
    static List<char> correctGuesses = new List<char>();
    static List<char> incorrectGuesses = new List<char>();
    static int maxTries = 6;
    static int triesLeft;

    static void Main(string[] args)
    {
        InitializeGame();
        PlayGame();
    }

    static void InitializeGame()
    {
        Random random = new Random();
        chosenWord = wordList[random.Next(wordList.Length)];
        triesLeft = maxTries;

        foreach (char c in chosenWord)
            correctGuesses.Add('_');
    }

    static void PlayGame()
    {
        while (!GameEnded())
        {
            DisplayGameState();
            AskForGuess();
        }

        Console.WriteLine(chosenWord);
        Console.WriteLine(GameWon() ? "Parabéns, você ganhou!" : "Você perdeu.");
    }

    static void DisplayGameState()
    {
        Console.WriteLine("\nPalavra: " + string.Join(" ", correctGuesses));
        Console.WriteLine("Tentativas Restantes: " + triesLeft);
        Console.WriteLine("Erros: " + string.Join(", ", incorrectGuesses));
    }

    static void AskForGuess()
    {
        Console.Write("Adivinhe uma letra: ");
        char guess = Char.ToLower(Console.ReadKey().KeyChar);
        Console.WriteLine();

        if (chosenWord.Contains(guess))
        {
            for (int i = 0; i < chosenWord.Length; i++)
                if (chosenWord[i] == guess)
                    correctGuesses[i] = guess;
        }
        else
        {
            if (!incorrectGuesses.Contains(guess))
            {
                incorrectGuesses.Add(guess);
                triesLeft--;
            }
        }
    }

    static bool GameEnded()
    {
        return GameWon() || triesLeft <= 0;
    }

    static bool GameWon()
    {
        return !correctGuesses.Contains('_');
    }
}
