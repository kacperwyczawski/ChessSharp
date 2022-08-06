using System;
using System.Collections.Generic;
using System.Drawing;

namespace ConsoleChess.ChessPieces;

/// <inheritdoc cref="ChessPiece"/>
public sealed class Bishop : ChessPiece
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Bishop"/> class.
    /// </summary>
    /// <param name="color">
    /// Color of chess piece.
    /// </param>
    public Bishop(Color color)
        : base(color)
    {
    }

    /// <inheritdoc/>
    public override char ToChar() => 'B';

    public override IEnumerable<Cell> GetValidMoves(Cell position, ChessBoard board)
    {
        // North-West direction
        for (int x = position.X - 1, y = position.Y - 1; x >= 0 && y >= 0; x--, y--)
        {
            if (board[x, y].IsOccupied)
                break;

            yield return board[x, y];
        }
        
        // North-East direction
        for (int x = position.X + 1, y = position.Y - 1; x <= 7 && y >= 0; x++, y--)
        {
            if (board[x, y].IsOccupied)
                break;

            yield return board[x, y];
        }
        
        // South-West direction
        for (int x = position.X - 1, y = position.Y + 1; x >= 0 && y <= 7; x--, y++)
        {
            if (board[x, y].IsOccupied)
                break;

            yield return board[x, y];
        }
        
        // South-East direction
        for (int x = position.X + 1, y = position.Y + 1; x <= 7 && y <= 7; x++, y++)
        {
            if (board[x, y].IsOccupied)
                break;

            yield return board[x, y];
        }
    }
}