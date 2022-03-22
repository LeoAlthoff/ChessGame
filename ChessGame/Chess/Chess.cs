using System;
using board;
using chess;
using System.Collections.Generic;

namespace chess
{
    class Chess
    {
        public Board board { get; private set; }
        public int turn { get; private set; }
        public Color CurrentPlayer { get; private set; }
        public bool finished { get; private set; }
        private List<Piece> pieces { get; set; }
        private List<Piece> captured { get; set; }
        public bool Check { get; private set; }

        public Chess()
        {
            board = new Board(8, 8);
            turn = 1;
            CurrentPlayer = Color.White;
            finished = false;
            pieces = new List<Piece>();
            captured = new List<Piece>();
            setGame();
        }



        public Piece ExecuteMove(Position origin, Position destiny)
        {
            Piece p = board.removePiece(origin);
            p.incrementMovements();
            Piece capturedPiece = board.removePiece(destiny);
            board.addPiece(p, destiny);
            if(capturedPiece != null)
            {
                captured.Add(capturedPiece);
            }    
            return capturedPiece;
        }


        public void undoMovement(Position origin, Position destiny, Piece capturedPiece)
        {
            Piece p = board.removePiece(destiny);
            p.decrementMovements();
            if(capturedPiece != null)
            {
                board.addPiece(capturedPiece, destiny);
                captured.Remove(capturedPiece);
            }
            board.addPiece(p, origin);
        }

        public void makeMove(Position origin, Position destiny)
        {
            Piece capturedPiece = ExecuteMove(origin, destiny);
            if (check(CurrentPlayer))
            {
                undoMovement(origin, destiny, capturedPiece);
                throw new BoardException("You cannot put yourself in check");
            }
            if (check(Adversary(CurrentPlayer)))
            {
                Check = true;
            }
            else
            {
                Check = false;
            }
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

        public List<Piece> capturedPieces(Color color)
        {
            List<Piece> aux = new List<Piece>();
            foreach(Piece x in captured)
            {
                if(x.Color == color)
                {
                    aux.Add(x);
                }
            }
            return aux;
        }

        public List<Piece> piecesInGame(Color color)
        {
            List<Piece> aux = new List<Piece>();
            foreach (Piece x in pieces)
            {
                if (x.Color == color)
                {
                    aux.Add(x);
                }
            }
            aux.Except(capturedPieces(color));
            return aux;
        }

        private Color Adversary(Color color)
        {
            if (color == Color.White)
            {
                return Color.Black;
            }
            else
            {
                return Color.White;
            }
        }

        private Piece colorKing(Color color)
        {
            foreach(Piece x in piecesInGame(color))
            {
                if(x is King)
                {
                    return x;
                }
            }
            return null;
        }

        public bool check(Color color)
        {
            Piece K = colorKing(color);
            
            foreach(Piece x in piecesInGame(Adversary(color))){
                bool[,] mat = x.possibleMoves();
                if(mat[K.Position.Line, K.Position.Column])
                {
                    return true;
                }
            }
            return false;
        }

        public void putNewPiece(char column, int line, Piece piece)
        {
            board.addPiece(piece, new ChessPosition(column, line).toPosition());
            pieces.Add(piece);
        }

        private void setGame()
        {

            putNewPiece('a', 1, new Rook(Color.White, board));
            putNewPiece('h', 1, new Rook(Color.White, board));
            putNewPiece('e', 1, new King(Color.White, board));
            putNewPiece('a', 8, new Rook(Color.Black, board));
            putNewPiece('h', 8, new Rook(Color.Black, board));
            putNewPiece('e', 8, new King(Color.Black, board));

        }
    }
}