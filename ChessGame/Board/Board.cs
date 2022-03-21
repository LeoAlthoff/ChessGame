using board;


namespace board
{
    class Board
    {
        public int Lines { get; set; }
        public int Columns { get; set; }
        private Piece[,] Pieces { get; set; }

        public Board(int lines, int columns)
        {
            Lines = lines;
            Columns = columns;
            Pieces = new Piece[lines, columns];
        }

        public Piece piece(int line, int column)
        {
            return Pieces[line, column];
        }

        public Piece piece(Position position)
        {
            return piece(position.Line, position.Column);
        }

        public bool pieceExistence(Position position)
        {
            validatePosition(position);
            return piece(position) != null;
        }

        public void addPiece(Piece piece, Position position)
        {
            if (!pieceExistence(position))
            {
                Pieces[position.Line, position.Column] = piece;
                piece.Position = position;
            }
            else
            {
                throw new BoardException("There's already a piece in this position!");
            }
        }

        public Piece removePiece(Position pos)
        {
            if (piece(pos) == null)
            {
                return null;
            }
            Piece aux = piece(pos);
            aux.Position = null;
            Pieces[pos.Line, pos.Column] = null;
            return aux;
        }

        public bool validPosition(Position position)
        {
            if (position.Line < 0 || position.Line >= Lines || position.Column < 0 || position.Column >= Columns)
            {
                return false;
            }
            return true;
        }

        public void validatePosition(Position position)
        {
            if (!validPosition(position))
                throw new BoardException("Not a Valid position!");
        }
    }
}
