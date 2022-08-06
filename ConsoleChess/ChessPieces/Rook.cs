using System.Collections.Generic;
using System.Drawing;

namespace ConsoleChess.ChessPieces;

/// <inheritdoc cref="ChessPiece"/>
public sealed class Rook : ChessPiece
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Rook"/> class.
    /// </summary>
    /// <param name="color">
    /// Color of chess piece.
    /// </param>
    public Rook(Color color)
        : base(color)
    {
    }

    /// <inheritdoc/>
    public override char ToChar() => 'R';

    public override IEnumerable<Cell> GetValidMoves(Cell position, ChessBoard board)
    {
        // West direction
        // x is decrementing, y is constant
        for (var i = position.X - 1; i >= 0; i--)
        {
            if (board[i, position.Y].IsOccupied)
                break;
            yield return board[i, position.Y];
        }
        
        // East direction
        // x is incrementing, y is constant
        for (var i = position.X + 1; i < 8; i++)
        {
            if (board[i, position.Y].IsOccupied)
                break;
            yield return board[i, position.Y];
        }
        
        // North direction
        // y is decrementing, x is constant
        for (var i = position.Y - 1; i >= 0; i--)
        {
            if (board[position.X, i].IsOccupied)
                break;
            yield return board[position.X, i];
        }
        
        // South direction
        // y is incrementing, x is constant
        for (var i = position.Y + 1; i < 8; i++)
        {
            if (board[position.X, i].IsOccupied)
                break;
            yield return board[position.X, i];
        }
    }
}
