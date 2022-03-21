using System;
using board;
using chess;

namespace chess
{
    class Chess
    {
        public Board board { get; private set; }
        private int turn;
        private Color CurrentPlayer;
        public bool finished { get; private set; }

        public Chess()
        {
            board = new Board(8, 8);
            turn = 1;
            CurrentPlayer = Color.White;
            finished = false;
            setGame();
        }

        public void ExecuteMove(Position origin, Position destiny)
        {
            Piece p = board.removePiece(origin);
            p.incrementMovements();
            Piece capturedPiece = board.removePiece(destiny);
            board.addPiece(p, destiny);
        }

        private void setGame()
        {
            board.addPiece(new King(Color.Black, board), new ChessPosition('e', 8).toPosition());
            board.addPiece(new Rook(Color.Black, board), new ChessPosition('d', 8).toPosition());
            board.addPiece(new King(Color.White, board), new ChessPosition('e', 1).toPosition());
            board.addPiece(new Rook(Color.White, board), new ChessPosition('d', 1).toPosition());
        }
    }
}
