using System;
using board;
using chess;

namespace ChessGame
{
    class Program
    {
        static void Main (string[] args)
        {
            Chess match = new Chess();
            while (!match.finished)
            {
                Console.Clear();
                Screen.printscreen(match.board);

                Console.WriteLine();
                Console.Write("Origin: ");
                Position origin = Screen.readChessPosition().toPosition();

                Console.Clear();

                bool[,] possiblePositions = match.board.piece(origin).possibleMoves();

                Screen.printscreen(match.board, possiblePositions);

                Console.WriteLine();
                Console.Write("Destiny: ");
                Position destiny = Screen.readChessPosition().toPosition();

                match.ExecuteMove(origin, destiny);

            }
        }
    }
}