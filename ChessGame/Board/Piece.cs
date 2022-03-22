namespace board
{
    abstract class Piece
    {
        public Position Position { get; set; }
        public Color Color { get; protected set; }
        public int Movements { get; protected set; }
        public Board board { get; protected set; }

        public Piece(Color color, Board board)
        {
            this.Position = null;
            this.Color = color;
            this.board = board;
            this.Movements = 0;
        }

        public void incrementMovements()
        {
            this.Movements++;
        }

        public void decrementMovements()
        {
            this.Movements--;
        }

        public abstract bool[,] possibleMoves();

        public bool existPossibleMoves()
        {
            bool[,] mat = possibleMoves();
            for (int i = 0; i < board.Lines; i++)
            {
                for (int j = 0; j < board.Columns; j++)
                {
                    if (mat[i, j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool canMoveTo(Position pos)
        {
            return possibleMoves()[pos.Line, pos.Column];
        }
    }
}
