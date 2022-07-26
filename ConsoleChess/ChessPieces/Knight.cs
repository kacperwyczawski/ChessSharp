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
    public override bool ValidateMove(Cell from, Cell to, ChessBoard board) =>
        ((from.X - 1 == to.X && from.Y - 2 == to.Y) ||
         (from.X + 1 == to.X && from.Y - 2 == to.Y) ||
         (from.X + 2 == to.X && from.Y - 1 == to.Y) ||
         (from.X + 2 == to.X && from.Y + 1 == to.Y) ||
         (from.X + 1 == to.X && from.Y + 2 == to.Y) ||
         (from.X - 1 == to.X && from.Y + 2 == to.Y) ||
         (from.X - 2 == to.X && from.Y + 1 == to.Y) ||
         (from.X - 2 == to.X && from.Y - 1 == to.Y)) &&
        to.IsOccupied == false;

    public override IEnumerable<Cell> GetValidMoves(Cell position, ChessBoard board)
    {
        throw new NotImplementedException();
    }
}