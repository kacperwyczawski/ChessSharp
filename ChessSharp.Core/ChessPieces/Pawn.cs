using System.Drawing;

namespace ChessSharp.Core.ChessPieces;

/// <inheritdoc cref="ChessPiece"/>
public sealed class Pawn : ChessPiece
{
    private readonly AttackDirection _direction;

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
        // This method could also be switch expression but in the future it will be refactored
        // to use cardinal directions instead of colors and methods would follow DRY.
        // Also pieces that uses directions would have IDirectional or similar interface.

        if (Color == Color.White)
            return GetValidMovesForWhite();
        
        if (Color == Color.Black)
            return GetValidMovesForBlack();
        
        throw new NotSupportedException("Color currently not supported");
    }

    private IEnumerable<Move> GetValidMovesForBlack()
    {
        // TODO: Implement changes from GetValidMovesForWhite, or even better, refactor this to follow DRY.
        
        // return if at the end of the board
        if (Position.Y == 7)
            yield break;
        
        // two squares move
        if (Position.Y == 1 && ParentBoard[Position.X, 3].IsOccupied == false)
            yield return new Move(ParentBoard[Position.X, 3], Position, null);
        
        // regular move
        if (ParentBoard[Position.X, Position.Y + 1].IsOccupied == false)
            yield return new Move(ParentBoard[Position.X, Position.Y + 1], Position, null);
        
        // capture left
        if (ParentBoard[Position.X - 1, Position.Y + 1] is var leftCell
            && leftCell.IsOccupied
            && leftCell.Piece?.Color != Color)
        {
            yield return new Move(leftCell, Position);
        }
        
        // capture right
        if (ParentBoard[Position.X + 1, Position.Y + 1] is var rightCell
            && rightCell.IsOccupied
            && rightCell.Piece?.Color != Color)
        {
            yield return new Move(rightCell, Position);
        }
    }

    private IEnumerable<Move> GetValidMovesForWhite()
    {
        // break if at the end of the board
        if (Position.Y == 0)
            yield break;
        
        // two squares move
        if (Position.Y == 6 && ParentBoard[Position.X, 4].IsOccupied == false)
            yield return new Move(ParentBoard[Position.X, 4], Position, null);
        
        // regular move
        if (ParentBoard[Position.X, Position.Y - 1].IsOccupied == false)
            yield return new Move(ParentBoard[Position.X, Position.Y - 1], Position, null);

        // captures on the left-hand side of pawn
        if (Position.X > 0)
        {
            // capture left
            if (ParentBoard[Position.X - 1, Position.Y - 1] is var leftCell
                && leftCell.IsOccupied
                && leftCell.Piece?.Color != Color)
            {
                yield return new Move(leftCell, Position);
            }
    
            // capture en passant left
            if (ParentBoard[Position.X - 1, Position.Y - 1] is var frontLeftCell
                && ParentBoard[Position.X - 1, Position.Y] is var backLeftCell
                // TODO: check in logs if last move was two squares pawn move
                // TODO: check in logs if pawn is on the right side of moved pawn
               )
            {
                yield return new Move(ParentBoard[Position.X + 1, Position.Y - 1],
                    Position, ParentBoard[Position.X + 1, Position.Y]);
            }
        }

        // captures on the right-hand side of pawn
        if (Position.X < 7)
        {
            // capture right

            if (ParentBoard[Position.X + 1, Position.Y - 1] is var rightCell
                && rightCell.IsOccupied
                && rightCell.Piece?.Color != Color)
            {
                yield return new Move(rightCell, Position);
            }

            // capture en passant right

            if (ParentBoard[Position.X + 1, Position.Y - 1] is var frontRightCell
                && ParentBoard[Position.X + 1, Position.Y] is var backRightCell
                // TODO: check in logs if last move was two squares pawn move
                // TODO: check in logs if pawn is on the left side of moved pawn
               )
            {
                yield return new Move(ParentBoard[Position.X - 1, Position.Y - 1],
                    Position, ParentBoard[Position.X - 1, Position.Y]);
            }
        }
    }
}