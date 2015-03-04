using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;

namespace HangMan
{
    class Engine : Contants
    {
        internal static void Main()
        {
            string file = string.Empty;
            string word = string.Empty;
            string gameInfo = string.Empty;
            int playerScores = 1;

            DrawingMethods.PrintLogo();
            DrawingMethods.Greetings();
            Console.Write("Моля изберете: [1]Класиране  [2]Нова игра :");
            int userChoice;
            while (!int.TryParse(Console.ReadLine(),out userChoice))
            {
                Console.Clear();
                DrawingMethods.PrintLogo();
                DrawingMethods.Greetings();
                Console.Write("Моля, въведете число! [1]Класиране  [2]Нова игра :");
            }
            if (userChoice == 1)
            {
                Console.Clear();
                DrawingMethods.PrintLogo();
                DrawingMethods.Greetings();
                Console.WriteLine();
                Console.WriteLine(" ------------- Класация ------------- ");
                Console.WriteLine();
                Scores.GetPlayersData();
            }
            else if (userChoice != 2)
            {
                while (userChoice!=1&&userChoice!=2)
                {
                    Console.Clear();
                    DrawingMethods.PrintLogo();
                    DrawingMethods.Greetings();
                    Console.WriteLine("Невалиден вход! Моля опитайте отново:");
                    Console.Write("Моля, въведете число! [1]Класиране  [2]Нова игра :");
                    while (!int.TryParse(Console.ReadLine(), out userChoice))
                    {
                        Console.Clear();
                        DrawingMethods.PrintLogo();
                        DrawingMethods.Greetings();
                        Console.Write("Моля, въведете число! [1]Класиране  [2]Нова игра :");
                    }

                }
                if (userChoice == 1)
                {
                    Scores.GetPlayersData();
                }
            }
            string playerName = LogicMethods.AskForName();
            int gameType = LogicMethods.AskForGameType();

            while (true)
            {
                if (gameType == 1)
                {
                    Console.Write("Изберете игра: [1]Градове      [2]Държави     : ");
                    int game;
                    while (!int.TryParse(Console.ReadLine(), out game))
                    {
                        Console.Clear();
                        DrawingMethods.PrintLogo();
                        DrawingMethods.Greetings();
                        Console.WriteLine("Моля, въведете число ! [1]Градове      [2]Държави     : ");
                    }
                    while (game != 1 && game != 2)
                    {
                        Console.Clear();
                        DrawingMethods.PrintLogo();
                        DrawingMethods.Greetings();
                        Console.WriteLine("Невалиден вход! Моля опитайте отново.");
                        Console.Write("Изберете игра: [1]Градове      [2]Държави     : ");
                        while (!int.TryParse(Console.ReadLine(), out game))
                        {
                            Console.Clear();
                            DrawingMethods.PrintLogo();
                            DrawingMethods.Greetings();
                            Console.WriteLine("Невалиден вход! Моля опитайте отново.");
                            Console.Write("Изберете игра: [1]Градове      [2]Държави     : ");
                            //Console.WriteLine("Моля, въведете число !");
                        }

                    }
                    file = LogicMethods.ChooseGame(game);
                    gameInfo = LogicMethods.GameInfo(game);
                    word = LogicMethods.GetRandomWord(file);
                    break;
                }

                else if (gameType == 2)
                {
                    Console.Write("Въведете дума : ");
                    word = Console.ReadLine().ToUpper();
                    gameInfo = "един срещу друг";
                    break;
                }

                else
                {
                    Console.Clear();
                    DrawingMethods.PrintLogo();
                    DrawingMethods.Greetings();
                    Console.WriteLine("Невалиден вход! Моля опитайте отново.");
                    gameType = LogicMethods.AskForGameType();
                }
            }

            StringBuilder wordForRecognition = new StringBuilder();
            if (word == null || word == "" || word == string.Empty)
            {
                throw new ArgumentException("Невалидна дума!");
            }
            else
            {
                wordForRecognition = LogicMethods.PrepareTheWord(word);
            }
            List<char> usedChars = new List<char>();

            Console.Clear();
            DrawingMethods.PrintGibbetAnimation();
            Console.Clear();
            counter = 0;
            while (wordForRecognition.ToString().Contains('_') && counter < MAX_MISTAKES)
            {
                DrawingMethods.PrintGibbet();
                Console.WriteLine("Вие играете {0}", gameInfo);
                //Console.WriteLine(word);
                Console.WriteLine("Грешни отговори : {0}/{1}", counter, MAX_MISTAKES);
                Console.Write("Използвани букви: ");

                foreach (var item in usedChars)
                {
                    Console.Write(item.ToString());
                }

                Console.WriteLine();
                Console.WriteLine(wordForRecognition);
                Console.Write("Буква : ");

                char guessChar ;
                while (!char.TryParse(Console.ReadLine(),out guessChar))
                {
                    DrawingMethods.PrintGibbet();
                    Console.WriteLine("Вие играете {0}", gameInfo);
                    //Console.WriteLine(word);
                    Console.WriteLine("Грешни отговори : {0}/{1}", counter, MAX_MISTAKES);
                    Console.Write("Използвани букви: ");

                    foreach (var item in usedChars)
                    {
                        Console.Write(item.ToString());
                    }

                    Console.WriteLine();
                    Console.WriteLine(wordForRecognition);
                    Console.Write("Буква : ");
                    Console.WriteLine();
                    //Console.WriteLine("Невалидна буква!");
                }

                if (!word.Contains(guessChar) || usedChars.Contains(guessChar))
                {
                    counter++;
                    if (counter == 7)
                    {

                        playerScores = 0;
                        Console.SetCursorPosition(coordinates[0, counter - 1], coordinates[1, counter - 1]);
                        Console.Write(bodyElements[counter - 1]);
                        Thread.Sleep(500);

                    }
                    DrawingMethods.DrawNextElementOnTheGibbet();
                }

                else
                {
                    for (int i = 0; i < word.Length; i++)
                    {
                        if (word[i] == guessChar)
                        {
                            wordForRecognition[i] = guessChar;
                        }
                    }
                }

                usedChars.Add(guessChar);

                if (wordForRecognition.ToString().Contains('_') || counter < MAX_MISTAKES)
                {
                    Console.SetCursorPosition(8, 7);
                    Console.Write("  ");
                }
            }

            Scores.UpdatePlayerData(playerName, playerScores);
            Console.Clear();
            int scores = Scores.GetPlayerScores(playerName);
            int games = Scores.GetPlayerGames(playerName);
            Console.WriteLine("{0} -> {1} точки от {2} изиграни игри!", playerName, scores, games);

            LogicMethods.EndOfTheGame(counter, MAX_MISTAKES, word);
        }
        
    }
}
