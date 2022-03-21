using System;
using board;

namespace chess
{
    class King : Piece
    {
        public King(Color color, Board board) : base(color, board)
        {
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
            return mat;
        }
    }
}
