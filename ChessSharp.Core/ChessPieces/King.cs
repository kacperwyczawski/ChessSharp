using System.Drawing;

namespace ChessSharp.Core.ChessPieces;

/// <inheritdoc cref="ChessPiece"/>
public sealed class King : ChessPiece
{
    /// <summary>
    /// Initializes a new instance of the <see cref="King"/> class.
    /// </summary>
    /// <inheritdoc/>
    public King(Color color, Cell position, ChessBoard parentBoard)
        : base(color, position, parentBoard)
    {
    }

    /// <inheritdoc/>
    public override char ToChar() => 'K';

    public override IEnumerable<Move> GetValidMoves()
    {
        // North
        if (Position.Y - 1 >= 0)
        {
            yield return new Move(Position.GetNorthNeighbor(), Position);
        }
        
        // North-East
        if (Position.X + 1 < 8 && Position.Y - 1 >= 0)
        {
            yield return new Move(Position.GetNorthEastNeighbor(), Position);
        }
        
        // East
        if (Position.X + 1 < 8)
        {
            yield return new Move(Position.GetEastNeighbor(), Position);
        }
        
        // South-East
        if (Position.X + 1 < 8 && Position.Y + 1 < 8)
        {
            yield return new Move(Position.GetSouthEastNeighbor(), Position);
        }
        
        // South
        if (Position.Y + 1 < 8)
        {
            yield return new Move(Position.GetSouthNeighbor(), Position);
        }
        
        // South-West
        if (Position.X - 1 >= 0 && Position.Y + 1 < 8)
        {
            yield return new Move(Position.GetSouthWestNeighbor(), Position);
        }
        
        // West
        if (Position.X - 1 >= 0)
        {
            yield return new Move(Position.GetWestNeighbor(), Position);
        }
        
        // North-West
        if (Position.X - 1 >= 0 && Position.Y - 1 >= 0)
        {
            yield return new Move(Position.GetNorthWestNeighbor(), Position);
        }
    }
}