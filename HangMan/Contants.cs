using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangMan
{
    internal class Contants
    {
        internal const int MAX_MISTAKES = 7;

        internal const char BODY = '\u258c';
        internal const char HEAD = '\u263A';
        internal const char DASH = '-';
        internal const char ASTERIX = '*';
        internal const char LEFT_DASH = '\\';
        internal const char RIGHT_DASH = '/';
        internal const char VERTICAL_DASH = '|';
        internal const char UNDER_SCORE = '_';
        internal const char EMPTY_SPACE = ' ';
        internal const char EQUALLY = '=';
        internal const char OPEN_BRACKET = '(';
        internal const char CLOSE_BRACKET = ')';

        internal const string GREETING = "Добре дошли!";
        internal const string CHOOSE_CATEGORY = "Моля, изберете желаната от Вас категория за игра: ";
        internal const string NUMBER_OF_CATEGORY = "<[ 1 - Държави ]> | <[ 2 - Градове ]> | <[ 3 - Други ]>";
        internal const string CATEGORY_REQUEST = "Моля въведете число за съответната категория -->> ";

        internal const string TEAM_NAME = "Powered by \"Hsu Hao\" Team";
        internal const string TELERIK_ACADEMY = "Online sudents on TelerikAcademy";

        internal static int counter = 0;

        internal static int[,] coordinates = 
            {
                {38, 38, 38, 37, 39, 37, 39},
                {3, 4, 5, 4, 4, 6, 6}
            };

        internal static char[] bodyElements = 
            {
                HEAD,
                VERTICAL_DASH,
                VERTICAL_DASH,
                LEFT_DASH,
                RIGHT_DASH,
                RIGHT_DASH,
                LEFT_DASH,
             };

    }
}
