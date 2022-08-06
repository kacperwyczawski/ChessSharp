using System;
using System.Collections.Generic;
using System.Drawing;

namespace ConsoleChess.ChessPieces;

/// <inheritdoc cref="ChessPiece"/>
public sealed class Pawn : ChessPiece
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Pawn"/> class.
    /// </summary>
    /// <inheritdoc/>
    public Pawn(Color color, Cell position, ChessBoard parentBoard)
        : base(color, position, parentBoard)
    {
    }

    /// <inheritdoc/>
    public override char ToChar() => 'P';

    public override IEnumerable<Cell> GetValidMoves()
    {
        if (Color == Color.White)
        {
            // at the edge of the board
            if (Position.Y == 0)
                yield break;
            
            // regular move
            if(ParentBoard[Position.X, Position.Y - 1].IsOccupied == false)
            {
                yield return ParentBoard[Position.X, Position.Y - 1];
            }

            // first move
            if (Position.Y == 6
                && ParentBoard[Position.X, Position.Y - 2].IsOccupied == false
                && ParentBoard[Position.X, Position.Y - 1].IsOccupied == false)
            {
                yield return ParentBoard[Position.X, Position.Y - 2];
            }
        }
        if (Color == Color.Black)
        {
            // at the edge of the board
            if (Position.Y == 7)
                yield break;
            
            // regular move
            if (ParentBoard[Position.X, Position.Y + 1].IsOccupied == false)
            {
                yield return ParentBoard[Position.X, Position.Y + 1];
            }

            // first move
            if (Position.Y == 1
                && ParentBoard[Position.X, Position.Y + 2].IsOccupied == false
                && ParentBoard[Position.X, Position.Y + 1].IsOccupied == false)
            {
                yield return ParentBoard[Position.X, Position.Y + 2];
            }
        }
    }
}