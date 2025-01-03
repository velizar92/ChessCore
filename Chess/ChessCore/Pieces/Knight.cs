using ChessCore.Enumerations;

namespace ChessCore.Pieces
{
    public class Knight : Piece
    {
        public Knight(IPosition position, PieceColor color) 
            : base(position, color)
        {
        }

        public override bool IsValidMove(IPosition newPosition, IBoard board)
        {
            throw new NotImplementedException();
        }
    }
}
