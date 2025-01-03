using ChessCore.Pieces;

namespace ChessCore
{
    public interface IBoard
    {
        Piece[,] ChessPieces { get; }

        void SetUpBoard();  

        void UpdatePiecePosition(IPosition positionFrom, IPosition positionTo);

        Piece GetPieceAt(IPosition position);
    }
}
