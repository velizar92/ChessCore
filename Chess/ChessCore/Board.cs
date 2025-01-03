using ChessCore.Enumerations;
using ChessCore.Exceptions;
using ChessCore.Pieces;

namespace ChessCore
{
    public class Board : IBoard
    {
        private static readonly HashSet<char> ValidFiles = new HashSet<char>()
        {
            'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H'
        };

        private static readonly HashSet<int> ValidRanks = new HashSet<int>()
        {
            1, 2, 3, 4, 5, 6, 7, 8
        };


        public Piece[,] ChessPieces { get; private set; }

        public Board()
        {
            ChessPieces = new Piece[8, 8];
            SetUpBoard();
        }

        public bool IsValidPosition(IPosition position)
        {
            if (position == null)
            {
                throw new ArgumentNullException(nameof(position), "The provided position is null.");
            }

            return ValidFiles.Contains(position.File) && ValidRanks.Contains(position.Rank);
        }

        public bool IsSquareEmpty(IPosition position)
        {
            var flattenedArray = ChessPieces.Cast<Piece>();

            return flattenedArray.FirstOrDefault(x => x.Position.File == position.File
                                        && x.Position.Rank == position.Rank) == null;
        }

        public bool IsSquareOcupiedByOponent(IPosition position, PieceColor opponentColor)
        {
            if (position == null)
            {
                throw new ArgumentNullException(nameof(position), "The provided position is null.");
            }

            if (IsValidPosition(position) == false)
            {
                throw new ArgumentException("The provided position is invalid.", nameof(position));
            }

            Piece piece = GetPieceAt(position);
           
            return piece != null && piece.Color != opponentColor;
        }

        public Piece GetPieceAt(IPosition position)
        {
            if (position == null)
            {
                throw new ArgumentNullException(nameof(position), "The provided position is null.");
            }

            if (ChessPieces == null)
            {
                throw new ArgumentNullException(nameof(position), "The provided position is null.");
            }

            var flattenedArray = ChessPieces.Cast<Piece>();

            return flattenedArray
                        .FirstOrDefault(x => x.Position.File == position.File
                             && x.Position.Rank == position.Rank) 
                             ?? throw new InvalidOperationException("No piece found at the specified position.");
        }

        public void UpdatePiecePosition(IPosition positionFrom, IPosition positionTo)
        {
            if (positionFrom == null)
            {
                throw new ArgumentNullException(nameof(positionFrom), "The provided position is null.");
            }

            if (positionTo == null)
            {
                throw new ArgumentNullException(nameof(positionTo), "The provided position is null.");
            }

            Piece piece = GetPieceAt(positionFrom);

            if (piece == null)
            {
                throw new PieceNotFoundException("No piece found at the starting position.", positionFrom);
            }

            if (piece.IsValidMove(positionTo, this))
            {
                piece.Position = positionTo;

                // Update the board array
                ChessPieces[positionTo.Rank - 1, positionTo.File - 'A'] = piece;
                ChessPieces[positionFrom.Rank - 1, positionFrom.File - 'A'] = null;
            }
        }

        private void SetUpBoard()
        {
            //Initializes white pieces

            ChessPieces[1, 0] = new Pawn(new Position('A', 2), PieceColor.White);
            ChessPieces[1, 1] = new Pawn(new Position('B', 2), PieceColor.White);
            ChessPieces[1, 2] = new Pawn(new Position('C', 2), PieceColor.White);
            ChessPieces[1, 3] = new Pawn(new Position('D', 2), PieceColor.White);
            ChessPieces[1, 4] = new Pawn(new Position('E', 2), PieceColor.White);
            ChessPieces[1, 5] = new Pawn(new Position('F', 2), PieceColor.White);
            ChessPieces[1, 6] = new Pawn(new Position('G', 2), PieceColor.White);
            ChessPieces[1, 7] = new Pawn(new Position('H', 2), PieceColor.White);

            ChessPieces[0, 0] = new Rook(new Position('A', 1), PieceColor.White);
            ChessPieces[0, 1] = new Knight(new Position('B', 1), PieceColor.White);
            ChessPieces[0, 2] = new Bishop(new Position('C', 1), PieceColor.White);
            ChessPieces[0, 3] = new Queen(new Position('D', 1), PieceColor.White);
            ChessPieces[0, 4] = new King(new Position('E', 1), PieceColor.White);
            ChessPieces[0, 5] = new Bishop(new Position('F', 1), PieceColor.White);
            ChessPieces[0, 6] = new Knight(new Position('G', 1), PieceColor.White);
            ChessPieces[0, 7] = new Rook(new Position('H', 1), PieceColor.White);

            //Initializes black pieces

            ChessPieces[6, 0] = new Pawn(new Position('A', 7), PieceColor.Black);
            ChessPieces[6, 1] = new Pawn(new Position('B', 7), PieceColor.Black);
            ChessPieces[6, 2] = new Pawn(new Position('C', 7), PieceColor.Black);
            ChessPieces[6, 3] = new Pawn(new Position('D', 7), PieceColor.Black);
            ChessPieces[6, 4] = new Pawn(new Position('E', 7), PieceColor.Black);
            ChessPieces[6, 5] = new Pawn(new Position('F', 7), PieceColor.Black);
            ChessPieces[6, 6] = new Pawn(new Position('G', 7), PieceColor.Black);
            ChessPieces[6, 7] = new Pawn(new Position('H', 7), PieceColor.Black);

            ChessPieces[7, 0] = new Rook(new Position('A', 8), PieceColor.Black);
            ChessPieces[7, 1] = new Knight(new Position('B', 8), PieceColor.Black);
            ChessPieces[7, 2] = new Bishop(new Position('C', 8), PieceColor.Black);
            ChessPieces[7, 3] = new Queen(new Position('D', 8), PieceColor.Black);
            ChessPieces[7, 4] = new King(new Position('E', 8), PieceColor.Black);
            ChessPieces[7, 5] = new Bishop(new Position('F', 8), PieceColor.Black);
            ChessPieces[7, 6] = new Knight(new Position('G', 8), PieceColor.Black);
            ChessPieces[7, 7] = new Rook(new Position('H', 8), PieceColor.Black);
        }
    }
}
