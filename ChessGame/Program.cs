using System;
using board;
using Chess;

namespace ChessGame
{
    class Program
    {
        static void Main (string[] args)
        {
            try
            {
                Board board = new Board(8, 8);

                board.addPiece(new Rook(Color.Black, board), new Position(0, 9));
                board.addPiece(new King(Color.Black, board), new Position(0, 0));
                board.addPiece(new King(Color.Black, board), new Position(2, 4));

                Screen.printscreen(board);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}