using System;
using board;
using Chess;

namespace ChessGame
{
    class Program
    {
        static void Main (string[] args)
        {
            Board board = new Board(8, 8);
            board.addPiece(new Rook(Color.Black, board), new Position(0, 0));
            board.addPiece(new King(Color.Black, board), new Position(1, 3));
            board.addPiece(new Rook(Color.White, board), new Position(2, 5));
            board.addPiece(new King(Color.White, board), new Position(7, 4));
            board.addPiece(new Rook(Color.Black, board), new Position(6, 2));


            Screen.printscreen(board);
        }
    }
}