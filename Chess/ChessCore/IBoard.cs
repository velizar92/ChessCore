using ChessCore.Enumerations;
using ChessCore.Pieces;

namespace ChessCore
{
    public interface IBoard
    {
        void UpdatePiecePosition(IPosition positionFrom, IPosition positionTo);

        Piece GetPieceAt(IPosition position);

        bool IsValidPosition(IPosition position);

        bool IsSquareEmpty(IPosition position);

        bool IsSquareOcupiedByOponent(IPosition position, PieceColor color);
    }
}
