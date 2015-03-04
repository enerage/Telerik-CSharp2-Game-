using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HangMan
{
    internal class DrawingMethods:Contants
    {
        internal static void PrintGibbetAnimation()
        {
            Console.Clear();

            for (int i = 0; i < 7; i++)
            {
                if (i == 3)
                {
                    Console.SetCursorPosition(7 - i, 7);
                    Console.WriteLine(EMPTY_SPACE);
                }

                else
                {
                    Console.SetCursorPosition(7 - i, 7);
                    Console.WriteLine(UNDER_SCORE);
                    Thread.Sleep(250);
                }
            }

            for (int i = 0; i < 6; i++)
            {
                Console.SetCursorPosition(4, 7 - i);
                Console.WriteLine(VERTICAL_DASH);
                Thread.Sleep(250);
            }

            for (int i = 0; i < 5; i++)
            {
                Console.SetCursorPosition(5 + i, 2);
                Console.WriteLine(DASH);
                Thread.Sleep(250);
            }

            Console.SetCursorPosition(10, 2);
            Console.WriteLine(VERTICAL_DASH);
            Thread.Sleep(250);

            PrintBodyAnimation();
        }

        internal static void PrintBodyAnimation()
        {
            for (int i = 0; i < 7; i++)
            {
                Console.SetCursorPosition(coordinates[0, i] - 28, coordinates[1, i]);
                Console.WriteLine(bodyElements[i]);
                Thread.Sleep(200);
            }

            Console.SetCursorPosition(15, 2);
            Console.WriteLine("Нинджа ти си следващият на бесилката!");
            Console.SetCursorPosition(15, 3);
            Console.WriteLine("Натисни Enter и да започваме!");

            bool isEnter = false;

            while (isEnter == false)
            {
                Console.SetCursorPosition(15, 4);
                ConsoleKeyInfo info = Console.ReadKey();
                if (info.Key == ConsoleKey.Enter)
                {
                    isEnter = true;
                    Console.Clear();
                }
            }
        }

        internal static void PrintGibbet()
        {
            for (int i = 0; i < 7; i++)
            {
                if (i == 3)
                {
                    Console.SetCursorPosition(35 - i, 7);
                    Console.WriteLine(EMPTY_SPACE);
                }

                else
                {
                    Console.SetCursorPosition(35 - i, 7);
                    Console.WriteLine(UNDER_SCORE);
                }
            }

            for (int i = 0; i < 6; i++)
            {
                Console.SetCursorPosition(32, 7 - i);
                Console.WriteLine(VERTICAL_DASH);
            }

            for (int i = 0; i < 5; i++)
            {
                Console.SetCursorPosition(33 + i, 2);
                Console.WriteLine(DASH);
            }

            Console.SetCursorPosition(38, 2);
            Console.WriteLine(VERTICAL_DASH);
            Console.SetCursorPosition(0, 2);

        }

        internal static void DrawNextElementOnTheGibbet()
        {
            Console.SetCursorPosition(coordinates[0, counter - 1], coordinates[1, counter - 1]);
            Console.Write(bodyElements[counter - 1]);
        }

        internal static void PrintLogo()
        {
            //headline
            Console.Write(new string(RIGHT_DASH, 3).PadLeft(20));
            Console.Write(new string(ASTERIX, 57));
            Console.WriteLine(new string(LEFT_DASH, 3));

            //HANGING 
            #region first row
            Console.Write(new string(RIGHT_DASH, 2).PadLeft(18));
            Console.Write(new string(VERTICAL_DASH, 2).PadLeft(16));
            Console.Write(new string(EMPTY_SPACE, 1));
            Console.Write(new string(VERTICAL_DASH, 2));
            Console.Write(new string(EMPTY_SPACE, 1));
            Console.Write(new string(RIGHT_DASH, 2));
            Console.Write(new string(LEFT_DASH, 2));
            Console.Write(new string(EMPTY_SPACE, 1));
            Console.Write(new string(VERTICAL_DASH, 2));
            Console.Write(new string(LEFT_DASH, 1));
            Console.Write(new string(EMPTY_SPACE, 1));
            Console.Write(new string(VERTICAL_DASH, 2));
            Console.Write(new string(EMPTY_SPACE, 1));
            Console.Write(new string(RIGHT_DASH, 2));
            Console.Write(new string(LEFT_DASH, 2));
            Console.Write(new string(EMPTY_SPACE, 1));
            Console.Write(new string(VERTICAL_DASH, 2));
            Console.Write(new string(EMPTY_SPACE, 1));
            Console.Write(new string(VERTICAL_DASH, 2));
            Console.Write(new string(LEFT_DASH, 1));
            Console.Write(new string(EMPTY_SPACE, 1));
            Console.Write(new string(VERTICAL_DASH, 2));
            Console.Write(new string(EMPTY_SPACE, 1));
            Console.Write(new string(RIGHT_DASH, 2));
            Console.Write(new string(LEFT_DASH, 2));
            Console.Write(new string(EMPTY_SPACE, 1));
            Console.WriteLine(new string(LEFT_DASH, 2).PadLeft(11));

            #endregion
            #region second row
            Console.Write(new string(RIGHT_DASH, 2).PadLeft(17));
            Console.Write(new string(VERTICAL_DASH, 2).PadLeft(17));
            Console.Write(new string(EQUALLY, 1));
            Console.Write(new string(VERTICAL_DASH, 4));
            Console.Write(new string(EQUALLY, 2));
            Console.Write(new string(VERTICAL_DASH, 4));
            Console.Write(new string(LEFT_DASH, 2));
            Console.Write(new string(VERTICAL_DASH, 4));
            Console.Write(new string(EMPTY_SPACE, 1));
            Console.Write(new string(UNDER_SCORE, 2));
            Console.Write(new string(EMPTY_SPACE, 1));
            Console.Write(new string(VERTICAL_DASH, 2));
            Console.Write(new string(EMPTY_SPACE, 1));
            Console.Write(new string(VERTICAL_DASH, 2));
            Console.Write(new string(LEFT_DASH, 2));
            Console.Write(new string(VERTICAL_DASH, 2));
            Console.Write(new string(VERTICAL_DASH, 2));
            Console.Write(new string(EMPTY_SPACE, 1));
            Console.Write(new string(UNDER_SCORE, 2));
            Console.WriteLine(new string(LEFT_DASH, 2).PadLeft(13));

            #endregion
            #region third row
            Console.Write(new string(RIGHT_DASH, 1).PadLeft(15));
            Console.Write(new string(VERTICAL_DASH, 2).PadLeft(19));
            Console.Write(new string(EMPTY_SPACE, 1));
            Console.Write(new string(VERTICAL_DASH, 4));
            Console.Write(new string(EMPTY_SPACE, 2));
            Console.Write(new string(VERTICAL_DASH, 4));
            Console.Write(new string(EMPTY_SPACE, 1));
            Console.Write(new string(LEFT_DASH, 1));
            Console.Write(new string(VERTICAL_DASH, 2));
            Console.Write(new string(EMPTY_SPACE, 1));
            Console.Write(new string(LEFT_DASH, 2));
            Console.Write(new string(RIGHT_DASH, 2));
            Console.Write(new string(EMPTY_SPACE, 1));
            Console.Write(new string(VERTICAL_DASH, 2));
            Console.Write(new string(EMPTY_SPACE, 1));
            Console.Write(new string(VERTICAL_DASH, 2));
            Console.Write(new string(EMPTY_SPACE, 1));
            Console.Write(new string(LEFT_DASH, 1));
            Console.Write(new string(VERTICAL_DASH, 2));
            Console.Write(new string(EMPTY_SPACE, 1));
            Console.Write(new string(LEFT_DASH, 2));
            Console.Write(new string(RIGHT_DASH, 2));

            Console.WriteLine(new string(LEFT_DASH, 1).PadLeft(14));

            #endregion

            #region The Gibbet
            //the gibbet header /   | ------ |    \
            Console.Write(new string(RIGHT_DASH, 1).PadLeft(14));
            Console.Write(new string(VERTICAL_DASH, 1).PadLeft(17));
            Console.Write(new string(DASH, 5));
            Console.Write(new string(VERTICAL_DASH, 1));
            Console.WriteLine(new string(LEFT_DASH, 1).PadLeft(47));

            //the gibbet (human arms and head) \   |   \☺/   /
            Console.Write(new string(LEFT_DASH, 1).PadLeft(14));
            Console.Write(new string(VERTICAL_DASH, 1).PadLeft(17));
            Console.Write(new string(EMPTY_SPACE, 4));
            Console.Write(new string(LEFT_DASH, 1));
            Console.Write(new string(HEAD, 1));
            Console.Write(new string(RIGHT_DASH, 1));
            Console.WriteLine(new string(RIGHT_DASH, 1).PadLeft(46));

            //the gibbet (human body)  \     |    ()     /
            Console.Write(new string(LEFT_DASH, 1).PadLeft(15));
            Console.Write(new string(VERTICAL_DASH, 1).PadLeft(16));
            Console.Write(new string(EMPTY_SPACE, 5));
            Console.Write(new string(BODY, 1));
            //Console.Write(new string(OPEN_BRACKET, 1));
            //Console.Write(new string(CLOSE_BRACKET, 1));
            Console.WriteLine(new string(RIGHT_DASH, 1).PadLeft(46));

            //the gibbet (human foots) \\     |  _/\_      //
            Console.Write(new string(LEFT_DASH, 2).PadLeft(17));
            Console.Write(new string(VERTICAL_DASH, 1).PadLeft(14));
            Console.Write(new string(EMPTY_SPACE, 3));
            Console.Write(new string(UNDER_SCORE, 1));
            Console.Write(new string(RIGHT_DASH, 1));
            Console.Write(new string(LEFT_DASH, 1));
            Console.Write(new string(UNDER_SCORE, 1));
            Console.Write(TEAM_NAME.PadLeft(39, EMPTY_SPACE));
            Console.WriteLine(new string(RIGHT_DASH, 2).PadLeft(5));

            //the gibbet bottom \\ _____|_____   //
            Console.Write(new string(LEFT_DASH, 2).PadLeft(18));
            Console.Write(new string(UNDER_SCORE, 3).PadLeft(12));
            Console.Write(new string(VERTICAL_DASH, 1));
            Console.Write(new string(UNDER_SCORE, 3));
            Console.Write(TELERIK_ACADEMY.PadLeft(43, EMPTY_SPACE));
            Console.WriteLine(new string(RIGHT_DASH, 2).PadLeft(4));

            #endregion

            //footer
            Console.Write(new string(LEFT_DASH, 3).PadLeft(20));
            Console.Write(new string(ASTERIX, 57));
            Console.WriteLine(new string(RIGHT_DASH, 3));
        }

        /// <summary>
        /// Print greetings and options
        /// </summary>
        internal static void Greetings()
        {
            Console.WriteLine(GREETING.PadLeft(55, EMPTY_SPACE));
        }
    }
}
