using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HangMan
{
    public class Scores
    {
        public static void UpdatePlayerData(string name, int scores)
        {
            StreamReader playerName = new StreamReader("playerName.txt", Encoding.GetEncoding("windows-1251"));
            StreamReader playerScores = new StreamReader("playerScores.txt", Encoding.GetEncoding("windows-1251"));
            StreamReader playerGames = new StreamReader("playerGames.txt", Encoding.GetEncoding("windows-1251"));

            List<string> playerNameList = playerName.ReadToEnd().Split(new string[] { " ", "  " },
                StringSplitOptions.RemoveEmptyEntries).ToList();
            List<string> playerScoresList = playerScores.ReadToEnd().Split(new string[] { " ", "  " },
                StringSplitOptions.RemoveEmptyEntries).ToList();
            List<string> playerGamesList = playerGames.ReadToEnd().Split(new string[] { " ", "  " },
                StringSplitOptions.RemoveEmptyEntries).ToList();

            for (int i = 0; i < playerNameList.Count; i++)
            {
                if (playerNameList[i] == name)
                {
                    int games = int.Parse(playerGamesList[i]);
                    games += 1;
                    playerGamesList[i] = games.ToString();

                    int newScores = int.Parse(playerScoresList[i]);
                    newScores += scores;
                    playerScoresList[i] = newScores.ToString();
                }
            }

            playerName.Close();
            playerScores.Close();
            playerGames.Close();

            StreamWriter newPlayersToAppend = new StreamWriter("playerName.txt", false, Encoding.GetEncoding("windows-1251"));
            StreamWriter newScoresToAppend = new StreamWriter("playerScores.txt", false, Encoding.GetEncoding("windows-1251"));
            StreamWriter newGamesToAppend = new StreamWriter("playerGames.txt", false, Encoding.GetEncoding("windows-1251"));

            for (int i = 0; i < playerNameList.Count; i++)
            {
                newPlayersToAppend.Write(playerNameList[i] + " ");
                newScoresToAppend.Write(playerScoresList[i] + " ");
                newGamesToAppend.Write(playerGamesList[i] + " ");
            }

            newPlayersToAppend.Close();
            newScoresToAppend.Close();
            newGamesToAppend.Close();

        }
        public static void GetPlayersData()
        {
            StreamReader playerName = new StreamReader("playerName.txt", Encoding.GetEncoding("windows-1251"));
            StreamReader playerScores = new StreamReader("playerScores.txt", Encoding.GetEncoding("windows-1251"));
            StreamReader playerGames = new StreamReader("playerGames.txt", Encoding.GetEncoding("windows-1251"));
            List<string> playerNameList = playerName.ReadToEnd().Split(new string[] { " ", "  " },
                StringSplitOptions.RemoveEmptyEntries).ToList();
            List<string> playerScoresList = playerScores.ReadToEnd().Split(new string[] { " ", "  " },
                StringSplitOptions.RemoveEmptyEntries).ToList();
            List<string> playerGamesList = playerGames.ReadToEnd().Split(new string[] { " ", "  " },
                StringSplitOptions.RemoveEmptyEntries).ToList();
            playerName.Close();
            playerScores.Close();
            playerGames.Close();

            for (int i = 0; i < playerNameList.Count; i++)
            {
                Console.WriteLine(playerNameList[i] + " -> " + playerScoresList[i] + " точки от " +
                    playerGamesList[i] + " изиграни игри!");
            }
            LogicMethods.ContinueMethod();
        }

        public static int GetPlayerGames(string name)
        {
            int player = 0;

            StreamReader playerName = new StreamReader("playerName.txt", Encoding.GetEncoding("windows-1251"));
            StreamReader playerGames = new StreamReader("playerGames.txt", Encoding.GetEncoding("windows-1251"));

            List<string> playerNameList = playerName.ReadToEnd().Split(new string[] { " ", "  " },
                StringSplitOptions.RemoveEmptyEntries).ToList();
            List<string> playerGamesList = playerGames.ReadToEnd().Split(new string[] { " ", "  " },
                StringSplitOptions.RemoveEmptyEntries).ToList();

            if (!playerNameList.Contains(name))
            {
                player = 0;
            }
            else
            {
                for (int i = 0; i < playerNameList.Count; i++)
                {
                    if (playerNameList[i] == name)
                    {
                        player = int.Parse(playerGamesList[i].ToString());
                    }
                }
            }

            playerName.Close();
            playerGames.Close();

            return player;
        }

        public static int GetPlayerScores(string name)
        {
            int player = 0;

            StreamReader playerName = new StreamReader("playerName.txt", Encoding.GetEncoding("windows-1251"));
            StreamReader playerScores = new StreamReader("playerScores.txt", Encoding.GetEncoding("windows-1251"));

            List<string> playerNameList = playerName.ReadToEnd().Split(new string[] { " ", "  " },
                StringSplitOptions.RemoveEmptyEntries).ToList();
            List<string> playerScoresList = playerScores.ReadToEnd().Split(new string[] { " ", "  " },
                StringSplitOptions.RemoveEmptyEntries).ToList();

            if (!playerNameList.Contains(name))
            {
                player = 0;
            }
            else
            {
                for (int i = 0; i < playerNameList.Count; i++)
                {
                    if (playerNameList[i] == name)
                    {
                        player = int.Parse(playerScoresList[i].ToString());
                    }
                }
            }

            playerName.Close();
            playerScores.Close();

            return player;
        }

        public static void InsertPlayer(string name)
        {
            bool existPlayer = false;

            StreamReader playerName = new StreamReader("playerName.txt", Encoding.GetEncoding("windows-1251"));
            StreamReader playerScores = new StreamReader("playerScores.txt", Encoding.GetEncoding("windows-1251"));
            StreamReader playerGames = new StreamReader("playerGames.txt", Encoding.GetEncoding("windows-1251"));
            List<string> playerNameList = playerName.ReadToEnd().Split(new string[] { " ", "  " },
                StringSplitOptions.RemoveEmptyEntries).ToList();
            List<string> playerScoresList = playerScores.ReadToEnd().Split(new string[] { " ", "  " },
                StringSplitOptions.RemoveEmptyEntries).ToList();
            List<string> playerGamesList = playerGames.ReadToEnd().Split(new string[] { " ", "  " },
                StringSplitOptions.RemoveEmptyEntries).ToList();
            int currentIndex = int.MinValue;

            for (int i = 0; i < playerNameList.Count; i++)
            {
                if (playerNameList[i] == name)
                {
                    currentIndex = i;
                    existPlayer = true;
                }
            }

            playerName.Close();
            playerScores.Close();
            playerGames.Close();

            if (!existPlayer)
            {
                playerNameList.Add(name);
                playerScoresList.Add("0");
                playerGamesList.Add("0");

                StreamWriter newPlayersToAppend = new StreamWriter("playerName.txt", false, Encoding.GetEncoding("windows-1251"));
                StreamWriter newScoresToAppend = new StreamWriter("playerScores.txt", false, Encoding.GetEncoding("windows-1251"));
                StreamWriter newGamesToAppend = new StreamWriter("playerGames.txt", false, Encoding.GetEncoding("windows-1251"));

                for (int i = 0; i < playerNameList.Count; i++)
                {
                    newPlayersToAppend.Write(playerNameList[i] + " ");
                    newScoresToAppend.Write(playerScoresList[i] + " ");
                    newGamesToAppend.Write(playerGamesList[i] + " ");
                }

                newPlayersToAppend.Close();
                newScoresToAppend.Close();
                newGamesToAppend.Close();
            }
        }
    }
}
