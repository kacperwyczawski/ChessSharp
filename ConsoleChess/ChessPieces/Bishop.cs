namespace ConsoleChess.ChessPieces;

using System.Drawing;

/// <inheritdoc cref="ChessPiece"/>
public class Bishop : ChessPiece
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
}