namespace ConsoleChess.ChessPieces;

using System.Drawing;

/// <inheritdoc cref="ChessPiece"/>
public sealed class Pawn : ChessPiece
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Pawn"/> class.
    /// </summary>
    /// <param name="color">
    /// Color of chess piece.
    /// </param>
    public Pawn(Color color)
        : base(color)
    {
    }

    /// <inheritdoc/>
    public override char ToChar() => 'P';

    /// <inheritdoc/>
    [Obsolete("Use GetValidMoves method instead.")]
    public override bool ValidateMove(Cell from, Cell to, ChessBoard board) =>
        ((from.X == to.X && from.Y - 1 == to.Y && Color == Color.White) || // regular move (when white)
         (from.X == to.X && from.Y + 1 == to.Y && Color == Color.Black) || // regular move (when black)
         (from.X == to.X && from.Y == 6 && to.Y == 4 && Color == Color.White) || // first move (when white)
         (from.X == to.X && from.Y == 1 && to.Y == 3 && Color == Color.Black)) && // first move (when black)
        to.IsOccupied == false;

    public override IEnumerable<Cell> GetValidMoves(Cell position, ChessBoard board)
    {
        if (Color == Color.White)
        {
            // at the edge of the board
            if (position.Y == 0)
                yield break;
            
            // regular move
            if(board[position.X, position.Y - 1].IsOccupied == false)
            {
                yield return board[position.X, position.Y - 1];
            }

            // first move
            if (position.Y == 6
                && board[position.X, position.Y - 2].IsOccupied == false
                && board[position.X, position.Y - 1].IsOccupied == false)
            {
                yield return board[position.X, position.Y - 2];
            }
        }
        if (Color == Color.Black)
        {
            // at the edge of the board
            if (position.Y == 7)
                yield break;
            
            // regular move
            if (board[position.X, position.Y + 1].IsOccupied == false)
            {
                yield return board[position.X, position.Y + 1];
            }

            // first move
            if (position.Y == 1
                && board[position.X, position.Y + 2].IsOccupied == false
                && board[position.X, position.Y + 1].IsOccupied == false)
            {
                yield return board[position.X, position.Y + 2];
            }
        }
    }
}