using board;

namespace chess
{
    class Knight : Piece
    {

        public Knight(Color color, Board board) : base(color, board)
        {

        }

        public override string ToString()
        {
            return "N";
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

            pos.defineValues(Position.Line - 1, Position.Column - 2);
            if (board.validPosition(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            pos.defineValues(Position.Line - 2, Position.Column - 1);
            if (board.validPosition(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            pos.defineValues(Position.Line - 1, Position.Column + 2);
            if (board.validPosition(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            pos.defineValues(Position.Line -2, Position.Column + 1);
            if (board.validPosition(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            pos.defineValues(Position.Line + 2, Position.Column - 1);
            if (board.validPosition(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            pos.defineValues(Position.Line + 2, Position.Column + 1);
            if (board.validPosition(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            pos.defineValues(Position.Line + 1, Position.Column + 2);
            if (board.validPosition(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;                
            }

            return mat;
        }
    }
}

