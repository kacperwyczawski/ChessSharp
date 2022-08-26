using System.ComponentModel;
using System.Drawing;

namespace ChessSharp.Core.ChessPieces;

/// <inheritdoc cref="ChessPiece"/>
public sealed class Pawn : ChessPiece
{
    private readonly AttackDirection _direction;
    
    // TODO: Implement, probably in base class
    private override bool _hasMoved = false;

    /// <summary>
    /// Initializes a new instance of the <see cref="Pawn"/> class.
    /// </summary>
    /// <inheritdoc/>
    public Pawn(Color color, Cell position, ChessBoard parentBoard, AttackDirection direction)
        : base(color, position, parentBoard)
    {
        _direction = direction;
    }

    /// <inheritdoc/>
    public override char ToChar() => 'P';

    public override IEnumerable<Move> GetValidMoves()
    {
        // --- setup ---
        
        var hasEdgeInFront = _direction switch
        {
            AttackDirection.North => Position.Y == 0,
            AttackDirection.South => Position.Y == 7,
            AttackDirection.East => Position.X == 0,
            AttackDirection.West => Position.X == 7,
            _ => throw new InvalidEnumArgumentException(
                nameof(_direction),
                (int)_direction,
                typeof(AttackDirection))
        };

        var hasEdgeAtLeft = _direction switch
        {
            AttackDirection.North => Position.X == 0,
            AttackDirection.South => Position.X == 7,
            AttackDirection.East => Position.Y == 0,
            AttackDirection.West => Position.Y == 7,
            _ => throw new InvalidEnumArgumentException(
                nameof(_direction),
                (int)_direction,
                typeof(AttackDirection))
        };
        
        var hasEdgeAtRight = _direction switch
        {
            AttackDirection.North => Position.X == 7,
            AttackDirection.South => Position.X == 0,
            AttackDirection.East => Position.Y == 7,
            AttackDirection.West => Position.Y == 0,
            _ => throw new InvalidEnumArgumentException(
                nameof(_direction),
                (int)_direction,
                typeof(AttackDirection))
        };

        // --- generate valid moves ---
        
        // break if pawn is at edge of board
        if (hasEdgeInFront)
            yield break;
        
        // regular move
        if (Position.GetFrontNeighbor(_direction).IsOccupied == false)
            yield return new Move(Position.GetFrontNeighbor(_direction), Position, null);
        
        // two square move
        if (_hasMoved == false
            && Position.GetFrontNeighbor(_direction).IsOccupied == false
            && Position.GetFrontNeighbor(_direction).GetFrontNeighbor(_direction) is var cellInFrontOfCellInFront
            && cellInFrontOfCellInFront.IsOccupied == false)
        {
            yield return new Move(cellInFrontOfCellInFront, Position, null);
        }

        // captures on the left-hand side of the pawn
        if (!hasEdgeAtLeft)
        {
            // capture left
            if (Position.GetFrontLeftNeighbor(_direction) is var leftCaptureCell
                && leftCaptureCell.IsOccupied
                && leftCaptureCell.Piece?.Color != Color)
            {
                yield return new Move(leftCaptureCell, Position);
            }
            
            // capture en passant left
            if (leftCaptureCell.IsOccupied == false
                // TODO: check in logs if last move was two squares pawn move
                // TODO: check in logs if piece on the left is that pawn which has just moved two squares
                //                        ^^^^^^^^^^^^^^^^^ <= Position.GetLeftNeighbor(_direction)
               )
            {
                yield return new Move(leftCaptureCell, Position, Position.GetLeftNeighbor(_direction));
            }
        }
        
        // captures on the right-hand side of the pawn
        if (!hasEdgeAtRight)
        {
            // capture right
            if (Position.GetFrontRightNeighbor(_direction) is var rightCaptureCell
                && rightCaptureCell.IsOccupied
                && rightCaptureCell.Piece?.Color != Color)
            {
                yield return new Move(rightCaptureCell, Position);
            }

            // capture en passant right
            if (rightCaptureCell.IsOccupied == false
                // TODO: check in logs if last move was two squares pawn move
                // TODO: check in logs if piece on the right is that pawn which has just moved two squares
                //                        ^^^^^^^^^^^^^^^^^ <= Position.GetRightNeighbor(_direction)
               )
            {
                yield return new Move(rightCaptureCell, Position, Position.GetRightNeighbor(_direction));
            }
        }
    }
}