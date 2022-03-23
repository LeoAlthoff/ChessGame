using board;

namespace chess
{
     class Queen : Piece
    {
        public Queen(Color color, Board board) : base(color, board)
        {
        }

        public override string ToString()
        {
            return "Q";
        }

        private bool canMove(Position pos)
        {
            Piece p = board.piece(pos);
            return p == null || p.Color != this.Color;
        }

        public override bool[,] possibleMoves()
        {
            bool[,] mat = new bool[board.Lines, board.Columns];

            Position pos = new Position(0, 0);

            //up
            pos.defineValues(Position.Line - 1, Position.Column);
            while (board.validPosition(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (board.piece(pos) != null && board.piece(pos).Color != Color)
                {
                    break;
                }
                pos.defineValues(Position.Line - 1, Position.Column);
            }


            //Northeast
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
            //Right
            pos.defineValues(Position.Line, Position.Column + 1);
            while (board.validPosition(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (board.piece(pos) != null && board.piece(pos).Color != Color)
                {
                    break;
                }
                pos.defineValues(Position.Line, Position.Column + 1);
            }

            //Southeast
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

            //South
            pos.defineValues(Position.Line + 1, Position.Column);
            while (board.validPosition(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (board.piece(pos) != null && board.piece(pos).Color != Color)
                {
                    break;
                }
                pos.defineValues(Position.Line + 1, Position.Column);
            }
            //Southwest
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
            //Left
            pos.defineValues(Position.Line, Position.Column - 1);
            while (board.validPosition(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (board.piece(pos) != null && board.piece(pos).Color != Color)
                {
                    break;
                }
                pos.defineValues(Position.Line, Position.Column - 1);
            }
            //Northwest
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
            return mat;

        }
    }
}
