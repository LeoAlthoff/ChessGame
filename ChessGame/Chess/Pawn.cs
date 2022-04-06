using board;
using chess;

namespace chess
{
    class Pawn : Piece
    {
        private Chess match;
        
        public Pawn(Color color, Board board, Chess match) : base(color, board)
        {
            this.match = match;
        }

        public override string ToString()
        {
            return "P";
        }

        private bool enimyExist(Position pos)
        {
            Piece p = board.piece(pos);
            return p != null && p.Color != Color;
        }

        private bool free(Position pos)
        {
            return board.piece(pos) == null;
        }

        public override bool[,] possibleMoves()
        {
            bool[,] mat = new bool[board.Lines, board.Columns];

            Position pos = new Position(0,0);

            if (Color == Color.White)
            {
                pos.defineValues(Position.Line - 1, Position.Column);
                if (board.validPosition(pos) && free(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }
                pos.defineValues(Position.Line - 2, Position.Column);
                if (board.validPosition(pos) && free(pos) && Movements == 0)
                {
                    mat[pos.Line, pos.Column] = true;
                }
                pos.defineValues(Position.Line - 1, Position.Column - 1);
                if (board.validPosition(pos) && enimyExist(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }
                pos.defineValues(Position.Line - 1, Position.Column + 1);
                if (board.validPosition(pos) && enimyExist(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }
                //EnPassant

                if (Position.Line == 3)
                {
                    Position left = new Position(Position.Line, Position.Column - 1);
                    if (board.validPosition(left) && enimyExist(left) && board.piece(left) == match.vulnerableEnPassant)
                    {
                        mat[left.Line - 1, left.Column] = true;
                    }
                    Position right = new Position(Position.Line, Position.Column + 1);
                    if (board.validPosition(right) && enimyExist(right) && board.piece(right) == match.vulnerableEnPassant)
                    {
                        mat[right.Line - 1, right.Column] = true;
                    }
                }
            }
            else
            {
                pos = new Position(0, 0);
                pos.defineValues(Position.Line + 1, Position.Column);
                if (board.validPosition(pos) && free(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }
                pos.defineValues(Position.Line + 2, Position.Column);
                if (board.validPosition(pos) && free(pos) && Movements == 0)
                {
                    mat[pos.Line, pos.Column] = true;
                }
                pos.defineValues(Position.Line + 1, Position.Column + 1);
                if (board.validPosition(pos) && enimyExist(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }
                pos.defineValues(Position.Line + 1, Position.Column - 1);
                if (board.validPosition(pos) && enimyExist(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }
                //EnPassant
                if (Position.Line == 4)
                {
                    Position left = new Position(Position.Line, Position.Column - 1);
                    if (board.validPosition(left) && enimyExist(left) && board.piece(left) == match.vulnerableEnPassant)
                    {
                        mat[left.Line + 1, left.Column] = true;
                    }
                    Position right = new Position(Position.Line, Position.Column + 1);
                    if (board.validPosition(right) && enimyExist(right) && board.piece(right) == match.vulnerableEnPassant)
                    {
                        mat[right.Line + 1, right.Column] = true;
                    }
                }
            }
            return mat;
        }

    }
}
