using System;
using Board;

namespace ChessGame
{
    class Program
    {
        static void Main (string[] args)
        {
            Position P = new Position(2, 3);

            Console.WriteLine("Position: " + P);
        }
    }
}