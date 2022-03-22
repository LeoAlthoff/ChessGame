using System;
using board;
using chess;

namespace chess
{
    class Chess
    {
        public Board board { get; private set; }
        public int turn { get; private set; }
        public Color CurrentPlayer { get; private set; }
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

        public void makeMove(Position origin, Position destiny)
        {
            ExecuteMove(origin, destiny);
            turn++;
            changePlayer();
        }

        public void validateOriginPosition(Position pos)
        {
            if (board.piece(pos) == null)
            {
                throw new BoardException("There isn't a piece on the selected square!");
            }
            if (CurrentPlayer != board.piece(pos).Color)
            {
                throw new BoardException("The selected piece is not yours!");
            }
            if (!board.piece(pos).existPossibleMoves())
            {
                throw new BoardException("There are no possible moves for the selected piece!");
            }
        }

        public void validateDestinyPosition(Position origin, Position destiny)
        {
            if (!board.piece(origin).canMoveTo(destiny))
            {
                throw new BoardException("Destiny is invalid!");
            }
        }

        private void changePlayer()
        {
            if (CurrentPlayer == Color.White)
            {
                CurrentPlayer = Color.Black;
            }
            else
            {
                CurrentPlayer = Color.White;
            }
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
