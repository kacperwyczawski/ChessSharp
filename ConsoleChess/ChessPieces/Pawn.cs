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
    public override bool ValidateMove((int x, int y) from, (int x, int y) to, ChessBoard board) =>
        ((from.x == to.x && from.y + 1 == to.y && Color == Color.White) || // regular move (when white)
         (from.x == to.x && from.y - 1 == to.y && Color == Color.Black) || // regular move (when black)
         (from.x == to.x && from.y == 1 && to.y == 3 && Color == Color.White) || // first move (when white)
         (from.x == to.x && from.y == 6 && to.y == 4 && Color == Color.Black)) && // first move (when black)
        board[to.x, to.y] is null;
}