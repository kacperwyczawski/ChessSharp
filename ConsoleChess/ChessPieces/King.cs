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
    public override bool ValidateMove(Cell from, Cell to, ChessBoard board) =>

        // vertical
        ((from.X - 1 == to.X && from.Y - 1 == to.Y) ||
         (from.X - 1 == to.X && from.Y + 1 == to.Y) ||
         (from.X + 1 == to.X && from.Y - 1 == to.Y) ||
         (from.X + 1 == to.X && from.Y + 1 == to.Y) ||

        // diagonal / horizontal
         (from.X - 1 == to.X && from.Y == to.Y) ||
         (from.X + 1 == to.X && from.Y == to.Y) ||
         (from.Y - 1 == to.Y && from.X == to.X) ||
         (from.Y + 1 == to.Y && from.X == to.X)) &&

        // destination must be empty
        to.IsOccupied == false;

    public override IEnumerable<Cell> GetValidMoves(Cell position, ChessBoard board)
    {
        throw new NotImplementedException();
    }
}