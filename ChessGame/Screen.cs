using System;
using board;
using chess;
using System.Collections.Generic;

namespace ChessGame
{
    class Screen
    {
        public static void printscreen(Board board)
        {                
            for (int i = 0; i < board.Lines; i++)
            {
                int line = 8 - i;
                Console.Write(line + " ");
                for (int j = 0; j < board.Columns; j++)
                {
                    printPiece(board.piece(i, j));
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h ");
        }

        public static void printscreen(Board board, bool[,] possiblePositions)
        {
            ConsoleColor consoleColor = Console.BackgroundColor;
            ConsoleColor alteredColor = ConsoleColor.DarkGray;

            for (int i = 0; i < board.Lines; i++)
            {
                int line = 8 - i;
                Console.Write(line + " ");
                for (int j = 0; j < board.Columns; j++)
                {
                    if(possiblePositions[i, j])
                    {
                        Console.BackgroundColor = alteredColor;
                    }
                    else
                    {
                        Console.BackgroundColor = consoleColor;
                    }
                    printPiece(board.piece(i, j));
                    Console.BackgroundColor = consoleColor;
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h ");
            Console.BackgroundColor = consoleColor;
        }

        static void printPiece(Piece piece)
        {

            if (piece == null)
            {
                Console.Write("- ");
            }
            else
            {
                if (piece.Color == Color.Black)
                {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write(piece);
                    Console.ForegroundColor = aux;
                }
                else
                {
                    Console.Write(piece);
                }
                Console.Write(" ");
            }
        }

        public static ChessPosition readChessPosition()
        {
            string s = Console.ReadLine();
            char column = s[0];
            int line = int.Parse(s[1] + "");
            return new ChessPosition(column, line);

        }
        public static void printCapturedPieces(Chess match)
        {
            Console.WriteLine("Captured Pieces: ");
            Console.Write("White: ");
            printList(match.capturedPieces(Color.White));
            Console.Write("Black: ");
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            printList(match.capturedPieces(Color.Black));
            Console.ForegroundColor = aux;
        }

        public static void printMatch(Chess match)
        {
            Screen.printscreen(match.board);
            Console.WriteLine();
            printCapturedPieces(match);
            Console.WriteLine();
            Console.WriteLine("Turn: " + match.turn);
            Console.WriteLine("Next move: " + match.CurrentPlayer);
        }
        

        public static void printList(List<Piece> pieces)
        {
            Console.Write("[");
            foreach(Piece piece in pieces)
            {
                Console.Write(piece + " ");
            }
            Console.WriteLine("]");
        }
    }
}