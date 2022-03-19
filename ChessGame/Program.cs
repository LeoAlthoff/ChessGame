using System;
using board;

namespace ChessGame
{
    class Program
    {
        static void Main (string[] args)
        {
            Position P = new Position(2, 3);

            Console.WriteLine("Position: " + P);

            Board board = new Board(8,8);

            Console.WriteLine(board);
        }
    }
}