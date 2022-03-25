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
        public Color currentPlayer { get; private set; }
        public bool finished { get; private set; }
        private List<Piece> pieces { get; set; }
        private List<Piece> captured { get; set; }
        public bool Check { get; private set; }
        public Piece vulnerableEnPassant { get; private set; }

        public Chess()
        {
            board = new Board(8, 8);
            turn = 1;
            currentPlayer = Color.White;
            finished = false;
            Check = false;
            vulnerableEnPassant = null;
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
            if (capturedPiece != null)
            {
                captured.Add(capturedPiece);
            }
            //King side Castle
            if (p is King && destiny.Column == origin.Column + 2)
            {
                Position originRook = new Position(origin.Line, origin.Column + 3);
                Position destinyRook = new Position(origin.Line, origin.Column + 1);
                Piece R = board.removePiece(originRook);
                R.incrementMovements();
                board.addPiece(R, destinyRook);
            }
            //Queen side Castle
            if (p is King && destiny.Column == origin.Column - 2)
            {
                Position originRook = new Position(origin.Line, origin.Column - 4);
                Position destinyRook = new Position(origin.Line, origin.Column - 1);
                Piece R = board.removePiece(originRook);
                R.incrementMovements();
                board.addPiece(R, destinyRook);
            }
            //EnPassant
            if (p is Pawn)
            {
                if (destiny.Column != origin.Column && capturedPiece == null)
                {
                    Position posP;
                    if (p.Color == Color.White)
                    {
                        posP = new Position(destiny.Line + 1, destiny.Column);
                    }
                    else
                    {
                        posP = new Position(destiny.Line - 1, destiny.Column);
                    }
                    capturedPiece = board.removePiece(posP);
                    captured.Add(capturedPiece);
                }
            }
            return capturedPiece;
        }


        public void undoMovement(Position origin, Position destiny, Piece capturedPiece)
        {
            Piece p = board.removePiece(destiny);
            p.decrementMovements();
            if (capturedPiece != null)
            {
                board.addPiece(capturedPiece, destiny);
                captured.Remove(capturedPiece);
            }
            board.addPiece(p, origin);

            //King side Castle
            if (p is King && destiny.Column == origin.Column + 2)
            {
                Position originRook = new Position(origin.Line, origin.Column + 3);
                Position destinyRook = new Position(origin.Line, origin.Column + 1);
                Piece R = board.removePiece(destinyRook);
                R.decrementMovements();
                board.addPiece(R, originRook);
            }
            //Queen side Castle
            if (p is King && destiny.Column == origin.Column - 2)
            {
                Position originRook = new Position(origin.Line, origin.Column - 4);
                Position destinyRook = new Position(origin.Line, origin.Column - 1);
                Piece R = board.removePiece(destinyRook);
                R.decrementMovements();
                board.addPiece(R, originRook);
            }
            //EnPassant
            if (p is Pawn)
            {
                if (destiny.Column != origin.Column && capturedPiece == vulnerableEnPassant)
                {
                    Piece pawn = board.removePiece(destiny);
                    Position posP;
                    if (p.Color == Color.White)
                    {
                        posP = new Position(3, destiny.Column);
                    }
                    else
                    {
                        posP = new Position(4, destiny.Column);
                    }
                    board.addPiece(pawn, posP);
                }
            }
        }

        public void makeMove(Position origin, Position destiny)
        {
            Piece capturedPiece = ExecuteMove(origin, destiny);
            if (check(currentPlayer))
            {
                undoMovement(origin, destiny, capturedPiece);
                throw new BoardException("You cannot put yourself in check");
            }

            Piece p = board.piece(destiny);

            //Promotion

            if (p is Pawn)
            {
                if (p.Color == Color.White && destiny.Line == 0 || p.Color == Color.Black && destiny.Line == 7)
                {
                    p = board.removePiece(destiny);
                    pieces.Remove(p);
                    Piece Queen = new Queen(p.Color, board);
                    board.addPiece(Queen, destiny);
                    pieces.Add(Queen);
                }
            }

            if (check(Adversary(currentPlayer)))
            {
                Check = true;
            }
            else
            {
                Check = false;
            }
            if (testCheckMate(Adversary(currentPlayer)))
            {
                finished = true;
            }
            else
            {
                if (currentPlayer == Color.Black)
                {
                    turn++;
                }
                changePlayer();
            }



            //EnPassant
            if (p is Pawn && (destiny.Line == origin.Line - 2 || destiny.Line == origin.Line + 2))
            {
                vulnerableEnPassant = p;
            }
            else
            {
                vulnerableEnPassant = null;
            }
        }

        public void validateOriginPosition(Position pos)
        {
            if (board.piece(pos) == null)
            {
                throw new BoardException("There isn't a piece on the selected square!");
            }
            if (currentPlayer != board.piece(pos).Color)
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
            if (currentPlayer == Color.White)
            {
                currentPlayer = Color.Black;
            }
            else
            {
                currentPlayer = Color.White;
            }
        }

        public List<Piece> capturedPieces(Color color)
        {
            List<Piece> aux = new List<Piece>();
            foreach (Piece x in captured)
            {
                if (x.Color == color)
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
            foreach (Piece x in piecesInGame(color))
            {
                if (x is King)
                {
                    return x;
                }
            }
            return null;
        }

        public bool check(Color color)
        {
            Piece K = colorKing(color);

            foreach (Piece x in piecesInGame(Adversary(color)))
            {
                bool[,] mat = x.possibleMoves();
                if (mat[K.Position.Line, K.Position.Column])
                {
                    return true;
                }
            }
            return false;
        }

        public bool testCheckMate(Color color)
        {
            if (!check(color))
            {
                return false;
            }
            foreach (Piece x in piecesInGame(color))
            {
                bool[,] mat = x.possibleMoves();
                for (int i = 0; i < board.Lines; i++)
                {
                    for (int j = 0; j < board.Columns; j++)
                    {
                        if (mat[i, j])
                        {
                            Position origin = x.Position;
                            Position destiny = new Position(i, j);
                            Piece capturedPiece = ExecuteMove(origin, destiny);
                            bool testcheck = check(color);
                            undoMovement(origin, destiny, capturedPiece);
                            if (!testcheck)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }

        public void putNewPiece(char column, int line, Piece piece)
        {
            board.addPiece(piece, new ChessPosition(column, line).toPosition());
            pieces.Add(piece);
        }

        private void setGame()
        {

            putNewPiece('a', 1, new Rook(Color.White, board));
            putNewPiece('b', 1, new Knight(Color.White, board));
            putNewPiece('c', 1, new Bishop(Color.White, board));
            putNewPiece('d', 1, new Queen(Color.White, board));
            putNewPiece('e', 1, new King(Color.White, board, this));
            putNewPiece('f', 1, new Bishop(Color.White, board));
            putNewPiece('g', 1, new Knight(Color.White, board));
            putNewPiece('h', 1, new Rook(Color.White, board));
            putNewPiece('a', 2, new Pawn(Color.White, board, this));
            putNewPiece('b', 2, new Pawn(Color.White, board, this));
            putNewPiece('c', 2, new Pawn(Color.White, board, this));
            putNewPiece('d', 2, new Pawn(Color.White, board, this));
            putNewPiece('e', 2, new Pawn(Color.White, board, this));
            putNewPiece('f', 2, new Pawn(Color.White, board, this));
            putNewPiece('g', 2, new Pawn(Color.White, board, this));
            putNewPiece('h', 2, new Pawn(Color.White, board, this));

            putNewPiece('a', 8, new Rook(Color.Black, board));
            putNewPiece('b', 8, new Knight(Color.Black, board));
            putNewPiece('c', 8, new Bishop(Color.Black, board));
            putNewPiece('d', 8, new Queen(Color.Black, board));
            putNewPiece('e', 8, new King(Color.Black, board, this));
            putNewPiece('f', 8, new Bishop(Color.Black, board));
            putNewPiece('g', 8, new Knight(Color.Black, board));
            putNewPiece('h', 8, new Rook(Color.Black, board));
            putNewPiece('a', 7, new Pawn(Color.Black, board, this));
            putNewPiece('b', 7, new Pawn(Color.Black, board, this));
            putNewPiece('c', 7, new Pawn(Color.Black, board, this));
            putNewPiece('d', 7, new Pawn(Color.Black, board, this));
            putNewPiece('e', 7, new Pawn(Color.Black, board, this));
            putNewPiece('f', 7, new Pawn(Color.Black, board, this));
            putNewPiece('g', 7, new Pawn(Color.Black, board, this));
            putNewPiece('h', 7, new Pawn(Color.Black, board, this));
        }
    }
}