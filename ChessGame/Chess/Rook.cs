using System;
using board;

namespace chess
{
    class Rook : Piece
    {
        public Rook(Color color, Board board) : base(color, board)
        {
        }

        public override string ToString()
        {
            return "R";
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
            while(board.validPosition(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if(board.piece(pos) != null && board.piece(pos).Color != Color)
                {
                    break;
                }
                pos.Line--;
            }
            //down
            pos.defineValues(Position.Line + 1, Position.Column);
            while (board.validPosition(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (board.piece(pos) != null && board.piece(pos).Color != Color)
                {
                    break;
                }
                pos.Line++;
            }
            //right
            pos.defineValues(Position.Line, Position.Column + 1);
            while (board.validPosition(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (board.piece(pos) != null && board.piece(pos).Color != Color)
                {
                    break;
                }
                pos.Column++;
            }
            //right
            pos.defineValues(Position.Line, Position.Column - 1);
            while (board.validPosition(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (board.piece(pos) != null && board.piece(pos).Color != Color)
                {
                    break;
                }
                pos.Column--;
            }

            return mat;
        }
    }
}