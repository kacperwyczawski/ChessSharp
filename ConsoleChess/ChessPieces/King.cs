using System.Collections.Generic;
using System.Drawing;

namespace ConsoleChess.ChessPieces;

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
        if (board[position.X - 1, position.Y - 1].IsOccupied == false)
            yield return board[position.X - 1, position.Y - 1];
        if (board[position.X - 1, position.Y + 1].IsOccupied == false)
            yield return board[position.X - 1, position.Y + 1];
        if (board[position.X + 1, position.Y - 1].IsOccupied == false)
            yield return board[position.X + 1, position.Y - 1];
        if (board[position.X + 1, position.Y + 1].IsOccupied == false)
            yield return board[position.X + 1, position.Y + 1];
        if (board[position.X - 1, position.Y].IsOccupied == false)
            yield return board[position.X - 1, position.Y];
        if (board[position.X + 1, position.Y].IsOccupied == false)
            yield return board[position.X + 1, position.Y];
        if (board[position.X, position.Y - 1].IsOccupied == false)
            yield return board[position.X, position.Y - 1];
        if (board[position.X, position.Y + 1].IsOccupied == false)
            yield return board[position.X, position.Y + 1];
    }
}