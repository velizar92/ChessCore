namespace ChessCore.Exceptions
{
    public class PieceNotFoundException : Exception
    {
        public IPosition Position { get; }

        public PieceNotFoundException(string message, IPosition position)
            :base(message)
        {
            Position = position;
        }
    }
}
