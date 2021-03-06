﻿using System;

namespace Connect4
{
    public class ConsoleEngine : Engine
    {
        public ConsoleEngine() : base()
        {

        }

        protected override short GetColumnMoveFromUser()
        {
            ConsoleKeyInfo key = Console.ReadKey();
            Console.WriteLine();
            int keyValue = (int)key.Key;
            int offSet = 97;
            keyValue = keyValue - offSet;
            return (short)keyValue;
        }

        protected override void PromptUserForMove()
        {
            //Console.WriteLine("Which column would you like to play at?");
        }

        protected override void InformUserInvalidMove()
        {
            Console.Clear();
            UpdateGUI();
            Console.WriteLine("That's not a valid move, please enter in another number.");
        }

        protected override void UpdateGUI()
        {
            //ulong board = player1.Bitboard | player2.Bitboard;
            ulong player1board = player1.Bitboard;
            ulong player2board = player2.Bitboard;
            ulong mask = 0x1;
            Console.Clear();
            Console.WriteLine("=================");
            Console.WriteLine("|   CONNECT 4   |");
            Console.WriteLine("|=1=2=3=4=5=6=7=|");
            for (int i = 0; i < 6; i++)
            {
                Console.Write("|");
                for (int j = 0; j < 7; j++)
                {
                    if ((player1board & mask) == mask)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(" O");
                        Console.ResetColor();
                    }
                    else if ((player2board & mask) == mask)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(" O");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write(" -");
                    }
                    mask = mask << 1;
                }
                Console.Write(" |\n");
            }
            Console.WriteLine("=================");
            Console.WriteLine();
        }

        protected override void InformPlayer1Win()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Player 1 Wins!");
            Console.ResetColor();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        protected override void InformPlayer2Win()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Player 2 Wins!");
            Console.ResetColor();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

    }
}
