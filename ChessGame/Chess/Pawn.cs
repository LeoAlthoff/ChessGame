using board;

namespace chess
{
    class Pawn : Piece
    {
        public Pawn(Color color, Board board) : base(color, board)
        {

        }

        public override string ToString()
        {
            return "P";
        }

        private bool enimyExist(Position pos)
        {
            Piece p = board.piece(pos);
            return p != null && p.Color != this.Color;
        }

        private bool free(Position pos)
        {
            return board.piece(pos) == null;
        }

        public override bool[,] possibleMoves()
        {
            bool[,] mat = new bool[board.Lines, board.Columns];

            Position pos = new Position(0, 0);


            if (Color == Color.White)
            {
                pos.defineValues(Position.Line - 1, Position.Column);
                if(board.validPosition(pos) && free(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }
                pos.defineValues(Position.Line - 2, Position.Column);
                if (board.validPosition(pos) && free(pos) && Movements == 0)
                {
                    mat[pos.Line, pos.Column] = true;
                }
                pos.defineValues(Position.Line - 1, Position.Column -1);
                if (board.validPosition(pos) && enimyExist(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }
                pos.defineValues(Position.Line - 1, Position.Column +1);
                if (board.validPosition(pos) && enimyExist(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }
            }
            else
            {
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
            }
            return mat;
        }

    }
}
