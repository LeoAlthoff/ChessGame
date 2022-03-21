using board;

namespace chess
{
    class ChessPosition
    {
        public char Column { get; set; }
        public int Line { get; set; }

        public ChessPosition(char column, int line)
        {
            this.Line = line;
            this.Column = column;
        }

        public override string ToString()
        {
            return "" + Column + Line;
        }

        public Position toPosition()
        {
            return new Position(8 - Line, Column - 'a');
        }
    }
}
