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
    public override bool ValidateMove(Cell from, Cell to, ChessBoard board) =>
        ((from.X == to.X && from.Y + 1 == to.Y && Color == Color.White) || // regular move (when white)
         (from.X == to.X && from.Y - 1 == to.Y && Color == Color.Black) || // regular move (when black)
         (from.X == to.X && from.Y == 1 && to.Y == 3 && Color == Color.White) || // first move (when white)
         (from.X == to.X && from.Y == 6 && to.Y == 4 && Color == Color.Black)) && // first move (when black)
        to.IsOccupied == false;
}