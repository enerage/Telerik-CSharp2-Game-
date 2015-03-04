using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangMan
{
    class LogicMethods
    {
        internal static string AskForName()
        {
            Console.Write("Вашето име: ");
            string playerName = Console.ReadLine();
            Scores.InsertPlayer(playerName);

            return playerName;
        }

        internal static int AskForGameType()
        {
            Console.Write("Изберете игра: [1]Един играч   [2]Двама играчи: ");
            int gameType;
            while (!int.TryParse(Console.ReadLine(),out gameType))
            {
                Console.Clear();
                DrawingMethods.PrintLogo();
                DrawingMethods.Greetings();
                Console.Write("Моля, въведете число ! [1]Един играч   [2]Двама играчи: "); 
            }
            return gameType;
        }

        internal static string GameInfo(int game)
        {
            string gameInfo = string.Empty;
            if (game == 1)
            {
                gameInfo = "Градове";
            }
            else if (game == 2)
            {
                gameInfo = "Държави";
            }
            else
            {
                var ex = new ArgumentException("Невалидни данни!");
                return ex.Message;
            }
            return gameInfo;
        }

        internal static string ChooseGame(int game)
        {
            string countriesFile = "Countries.txt";
            string citiesFile = "Cities.txt";
            if (game == 1)
            {
                return citiesFile;
            }
            else if (game == 2)
            {
                return countriesFile;
            }
            else
            {
                var ex = new ArgumentException("Невалидни данни!");
                return ex.Message;
            }
        }

        internal static string GetRandomWord(string file)
        {
            StreamReader text = new StreamReader(file, Encoding.GetEncoding("windows-1251"));
            var wordCollection = text.ReadToEnd();
            string[] words = wordCollection.Split(new string[] { " - " }, StringSplitOptions.RemoveEmptyEntries);

            Random rand = new Random();
            int randomIndex = rand.Next(0, words.Length);
            string randomWord = words[randomIndex].ToUpper();
            return randomWord;
        }

        internal static StringBuilder PrepareTheWord(string word)
        {
            StringBuilder wordForRecognition = new StringBuilder();
            wordForRecognition.Append(new string('_', word.Length));
            wordForRecognition[0] = word[0];
            wordForRecognition[wordForRecognition.Length - 1] = word[word.Length - 1];
            if (word.IndexOf(' ') > 0)
            {
                int index = 0;
                while (true)
                {
                    index = word.IndexOf(' ', index);
                    if (index >= 0)
                    {
                        wordForRecognition[index] = ' ';
                        wordForRecognition[index - 1] = word[index - 1];
                        wordForRecognition[index + 1] = word[index + 1];
                    }
                    else
                    {
                        break;
                    }
                    index++;
                }
            }
            StringBuilder preparedWord = new StringBuilder();
            preparedWord = wordForRecognition;
            return preparedWord;
        }

        internal static void EndOfTheGame(int counter, int MAX_MISTAKES, string randomCountry)
        {
            if (counter < MAX_MISTAKES)
            {
                if (counter == 1)
                {
                    Console.WriteLine("Поздравления! Спечели играта с {0} грешка", counter);
                }
                else
                {
                    Console.WriteLine("Поздравления! Спечели играта с {0} грешки", counter);
                }
            }
            else
            {
                Console.WriteLine("Играта свърши!");
            }
            Console.WriteLine("Думата е : {0} ", randomCountry);

            Console.WriteLine("Натисни Enter за нова игра...");

            bool newGame = false;
            while (newGame == false)
            {
                Console.SetCursorPosition(0, 4);
                ConsoleKeyInfo info = Console.ReadKey();

                if (info.Key == ConsoleKey.Enter)
                {
                    newGame = true;
                    Console.Clear();
                    Engine.Main();
                }
            }
        }
        public static void ContinueMethod()
        {
            Console.WriteLine("\nИскате ли да играете:(ENTER)Да   (ESC)Не");
            ConsoleKeyInfo quitOrPlay = Console.ReadKey();
            while (quitOrPlay.Key != ConsoleKey.Escape && quitOrPlay.Key != ConsoleKey.Enter)
            {
                quitOrPlay = Console.ReadKey();
            }
            if (quitOrPlay.Key == ConsoleKey.Escape)
            {
                Environment.Exit(1);
            }
            else if (quitOrPlay.Key == ConsoleKey.Enter)
            {
                Console.Clear();
                DrawingMethods.PrintLogo();
                DrawingMethods.Greetings();

                return;
            }
        }
        
    }
}
