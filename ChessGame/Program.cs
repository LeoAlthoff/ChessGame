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
                try
                {
                    Console.Clear();
                    Screen.printMatch(match);

                    Console.WriteLine();
                    Console.Write("Origin: ");
                    Position origin = Screen.readChessPosition().toPosition();
                    match.validateOriginPosition(origin);

                    Console.Clear();

                    bool[,] possiblePositions = match.board.piece(origin).possibleMoves();

                    Screen.printscreen(match.board, possiblePositions);

                    Console.WriteLine();
                    Console.Write("Destiny: ");
                    Position destiny = Screen.readChessPosition().toPosition();
                    match.validateDestinyPosition(origin, destiny);

                    match.makeMove(origin, destiny);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.ReadLine();
                }

            }
        }
    }
}