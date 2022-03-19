using System;
using board;
using Chess;

namespace ChessGame
{
    class Program
    {
        static void Main (string[] args)
        {
            ChessPosition position = new ChessPosition('c', 7);

            Console.WriteLine(position);

            Console.WriteLine(position.toPosition());

        }
    }
}