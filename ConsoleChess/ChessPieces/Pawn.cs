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
        // return if at the end of the board
        if (Position.Y == 0)
            yield break;
        
        // two squares move
        if (Position.Y == 6 && ParentBoard[Position.X, 4].IsOccupied == false)
            yield return new Move(ParentBoard[Position.X, 4], Position, null);
        
        // regular move
        if (ParentBoard[Position.X, Position.Y - 1].IsOccupied == false)
            yield return new Move(ParentBoard[Position.X, Position.Y - 1], Position, null);
        
        // capture left
        if (ParentBoard[Position.X - 1, Position.Y - 1] is var leftCell
            && leftCell.IsOccupied
            && leftCell.Piece?.Color != Color)
        {
            yield return new Move(leftCell, Position);
        }

        // capture right
        if (ParentBoard[Position.X + 1, Position.Y - 1] is var rightCell
            && rightCell.IsOccupied
            && rightCell.Piece?.Color != Color)
        {
            yield return new Move(rightCell, Position);
        }
    }
}