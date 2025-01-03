using ChessCore.Enumerations;

namespace ChessCore.Pieces
{
    public abstract class Piece
    {
        protected Piece(IPosition position, PieceColor color)
        {
            Position = position;
            Color = color;
        }

        public IPosition Position { get; set; }
        public PieceColor Color { get; set; }

        public abstract bool IsValidMove(IPosition newPosition, IBoard board);
    }
}
