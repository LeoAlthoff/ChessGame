using System;
using board;
using chess;

namespace chess
{
    class King : Piece
    {
        private Chess match;

        public King(Color color, Board board, Chess match) : base(color, board)
        {
            this.match = match;
        }

        public override string ToString()
        {
            return "K";
        }

        private bool canMove(Position pos)
        {
            Piece p = board.piece(pos);
            return p == null || p.Color != this.Color;
        }

        private bool RookTestCastle(Position pos)
        {
            Piece R = board.piece(pos);            
            return pos != null && R is Rook && R.Color == this.Color && R.Movements == 0;
        }

        public override bool[,] possibleMoves()
        {
            bool[,] mat = new bool[board.Lines, board.Columns];

            Position pos = new Position(0, 0);

            //up
            pos.defineValues(Position.Line - 1, Position.Column);
            if (board.validPosition(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            //Northeast
            pos.defineValues(Position.Line - 1, Position.Column + 1);
            if (board.validPosition(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            //Right
            pos.defineValues(Position.Line, Position.Column + 1);
            if (board.validPosition(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            //Southeast
            pos.defineValues(Position.Line + 1, Position.Column + 1);
            if (board.validPosition(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            //South
            pos.defineValues(Position.Line + 1, Position.Column);
            if (board.validPosition(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            //Southwest
            pos.defineValues(Position.Line + 1, Position.Column - 1);
            if (board.validPosition(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            //Left
            pos.defineValues(Position.Line, Position.Column - 1);
            if (board.validPosition(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            //Northwest
            pos.defineValues(Position.Line - 1, Position.Column - 1);
            if (board.validPosition(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            //King side castle
            if(Movements == 0 && !match.Check)
            {
                Position posR1 = new Position(Position.Line, Position.Column + 3);
                if (RookTestCastle(posR1))
                {
                    Position p1 = new Position(Position.Line, Position.Column + 1);
                    Position p2 = new Position(Position.Line, Position.Column + 2);
                    if(board.piece(p1) == null && board.piece(p2) == null)
                    {
                        mat[Position.Line, Position.Column + 2] = true;
                    }
                }
            }
            //Queen side castle
            if (Movements == 0 && !match.Check)
            {
                Position posR2 = new Position(Position.Line, Position.Column - 4);
                if (RookTestCastle(posR2))
                {
                    Position p1 = new Position(Position.Line, Position.Column - 1);
                    Position p2 = new Position(Position.Line, Position.Column - 2);
                    Position p3 = new Position(Position.Line, Position.Column - 3);
                    if (board.piece(p1) == null && board.piece(p2) == null && board.piece(p3) == null)
                    {
                        mat[Position.Line, Position.Column - 2] = true;
                    }
                }
            }
            return mat;
        }
    }
}
