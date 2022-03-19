namespace board
{
    internal class Piece
    {
        public Position Position { get; set; }
        public Color Color { get; protected set; }
        public int Movements { get; protected set; }
        public Board Board { get; protected set; }

        public Piece(Position position, Color color, Board board)
        {
            this.Position = position;
            this.Color = color;
            this.Board = board;
            this.Movements = 0;
        }
    }
}
