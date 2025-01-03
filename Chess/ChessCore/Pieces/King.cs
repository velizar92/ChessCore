using ChessCore.Enumerations;

namespace ChessCore.Pieces
{
    public class King : Piece
    {
        public King(IPosition position, PieceColor color) 
            : base(position, color)
        {
        }

        public override bool IsValidMove(IPosition newPosition, IBoard board)
        {
            throw new NotImplementedException();
        }
    }
}
