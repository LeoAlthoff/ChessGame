namespace board
{
    class Position
    {
        public int Line { get; set; }
        public int Column { get; set; }

        public Position(int lines, int column)
        {
            this.Line = lines;
            this.Column = column;
        }

        public void defineValues(int lines, int column)
        {
            this.Line = lines;
            this.Column = column;
        }

        public override string ToString()
        {
            return Line + ", " + Column;
        }
    }
}
