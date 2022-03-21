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

        public abstract bool[,] possibleMoves();
    }
}
