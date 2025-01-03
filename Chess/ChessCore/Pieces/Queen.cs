using ChessCore.Enumerations;

namespace ChessCore.Pieces
{
    public class Queen : Piece
    {
        public Queen(IPosition position, PieceColor color) 
            : base(position, color)
        {
        }

        public override bool IsValidMove(IPosition newPosition, IBoard board)
        {
            throw new NotImplementedException();
        }
    }
}
