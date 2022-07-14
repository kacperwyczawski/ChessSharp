namespace ConsoleChess.ChessPieces;

using System.Drawing;

/// <inheritdoc cref="ChessPiece"/>
public sealed class Knight : ChessPiece
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Knight"/> class.
    /// </summary>
    /// <param name="color">
    /// Color of chess piece.
    /// </param>
    public Knight(Color color)
        : base(color)
    {
    }

    /// <inheritdoc/>
    public override char ToChar() => 'N';

    /// <inheritdoc/>
    public override bool ValidateMove((int x, int y) from, (int x, int y) to, ChessBoard board) =>
        ((from.x - 1 == to.x && from.y - 2 == to.y) ||
         (from.x + 1 == to.x && from.y - 2 == to.y) ||
         (from.x + 2 == to.x && from.y - 1 == to.y) ||
         (from.x + 2 == to.x && from.y + 1 == to.y) ||
         (from.x + 1 == to.x && from.y + 2 == to.y) ||
         (from.x - 1 == to.x && from.y + 2 == to.y) ||
         (from.x - 2 == to.x && from.y + 1 == to.y) ||
         (from.x - 2 == to.x && from.y - 1 == to.y)) &&
        board[to.x, to.y] is null;
}