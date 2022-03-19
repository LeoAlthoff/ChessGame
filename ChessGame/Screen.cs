using System;
using board;

namespace ChessGame
{
    internal class Screen
    {
        public static void printscreen(Board board)
        {
            for (int i = 0; i < board.Lines; i++)
            {
                int line = 8 - i;
                Console.Write(line + " ");
                for (int j = 0; j < board.Columns; j++)
                {

                    if (board.piece(i,j) == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        Screen.printPiece(board.piece(i, j));
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h ");

        }

        static void printPiece(Piece piece)
        {
            if (piece.Color == Color.Black)
            {
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(piece);
                Console.ForegroundColor= aux;
            }
            else
            {
                Console.Write(piece);
            }
        }
    }
}