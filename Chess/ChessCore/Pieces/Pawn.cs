using ChessCore.Enumerations;

namespace ChessCore.Pieces
{
    public class Pawn : Piece
    {
        public Pawn(IPosition position, PieceColor color) 
            : base(position, color)
        {
        }

        public override bool IsValidMove(IPosition newPosition, IBoard board)
        {
            throw new NotImplementedException();
        }
    }
}
