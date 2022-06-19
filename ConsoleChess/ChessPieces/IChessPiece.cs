namespace ConsoleChess.ChessPieces;

/// <summary>
/// Represents single chess piece.
/// </summary>
public interface IChessPiece
{
    /// <summary>
    /// Converts chess piece to it's <see cref="char"/> representation.
    /// </summary>
    /// <returns>
    /// The <see cref="char"/> representation of object.
    /// </returns>
    public char ToChar();
}