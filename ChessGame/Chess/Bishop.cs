using board;

namespace chess
{
    class Bishop : Piece
    {
        public Bishop(Color color, Board board) : base(color, board)
        {

        }

        public override string ToString()
        {
            return "B";
        }

        private bool canMove(Position pos)
        {
            Piece p = board.piece(pos);
            return p == null || p.Color != this.Color;
        }

        public override bool[,] possibleMoves()
        {
            bool[,] mat = new bool[board.Columns, board.Lines];

            Position pos = new Position(0, 0);

            //ne
            pos.defineValues(Position.Line - 1, Position.Column + 1);
            while (board.validPosition(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (board.piece(pos) != null && board.piece(pos).Color != Color)
                {
                    break;
                }
                pos.defineValues(Position.Line - 1, Position.Column + 1);
            }
            //nw
            pos.defineValues(Position.Line - 1, Position.Column - 1);
            while (board.validPosition(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (board.piece(pos) != null && board.piece(pos).Color != Color)
                {
                    break;
                }
                pos.defineValues(Position.Line - 1, Position.Column - 1);
            }
            //se
            pos.defineValues(Position.Line + 1, Position.Column + 1);
            while (board.validPosition(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (board.piece(pos) != null && board.piece(pos).Color != Color)
                {
                    break;
                }
                pos.defineValues(Position.Line + 1, Position.Column + 1);
            }
            //sw
            pos.defineValues(Position.Line + 1, Position.Column - 1);
            while (board.validPosition(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (board.piece(pos) != null && board.piece(pos).Color != Color)
                {
                    break;
                }
                pos.defineValues(Position.Line + 1, Position.Column - 1);
            }

            return mat;
        }
    }
}
