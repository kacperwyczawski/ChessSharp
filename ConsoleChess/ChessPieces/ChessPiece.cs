namespace ConsoleChess.ChessPieces;

using System.Drawing;

/// <summary>
/// Represents single chess piece.
/// </summary>
public abstract class ChessPiece
{
    private bool Equals(ChessPiece other)
    {
        return Color.Equals(other.Color);
    }

    /// <inheritdoc/>
    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj))
            return false;
        if (ReferenceEquals(this, obj))
            return true;
        if (obj.GetType() != GetType())
            return false;
        return Equals((ChessPiece)obj);
    }

    public override int GetHashCode()
    {
        return Color.GetHashCode();
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ChessPiece"/> class.
    /// </summary>
    /// <param name="color">
    /// Color of chess piece.
    /// </param>
    public ChessPiece(Color color)
    {
        Color = color;
    }

    /// <summary>
    /// Gets color of chess piece.
    /// </summary>
    public Color Color { get; }

    /// <summary>
    /// Converts chess piece to it's <see cref="char"/> representation.
    /// </summary>
    /// <returns>
    /// The <see cref="char"/> representation of object.
    /// </returns>
    public abstract char ToChar();

    /// <summary>
    /// Checks if move is valid.
    /// </summary>
    /// <param name="from">starting index.</param>
    /// <param name="to">target index.</param>
    /// <param name="board">parent board.</param>
    /// <returns>True when move is valid, false when not.</returns>
    public abstract bool ValidateMove(Cell from, Cell to, ChessBoard board);
}