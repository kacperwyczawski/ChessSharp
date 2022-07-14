namespace ConsoleChess.ChessPieces;

using System.Drawing;

/// <inheritdoc cref="ChessPiece"/>
public sealed class King : ChessPiece
{
    /// <summary>
    /// Initializes a new instance of the <see cref="King"/> class.
    /// </summary>
    /// <param name="color">
    /// Color of chess piece.
    /// </param>
    public King(Color color)
        : base(color)
    {
    }

    /// <inheritdoc/>
    public override char ToChar() => 'K';

    /// <inheritdoc/>
    public override bool ValidateMove((int x, int y) from, (int x, int y) to, ChessBoard board) =>

        // vertical
        ((from.x - 1 == to.x && from.y - 1 == to.y) ||
         (from.x - 1 == to.x && from.y + 1 == to.y) ||
         (from.x + 1 == to.x && from.y - 1 == to.y) ||
         (from.x + 1 == to.x && from.y + 1 == to.y) ||

        // diagonal / horizontal
         (from.x - 1 == to.x && from.y == to.y) ||
         (from.x + 1 == to.x && from.y == to.y) ||
         (from.y - 1 == to.y && from.x == to.x) ||
         (from.y + 1 == to.y && from.x == to.x)) &&

        // destination must be empty
        board[to.x, to.y] is null;
}