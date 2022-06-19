namespace ConsoleChess.ChessPieces;

/// <inheritdoc cref="IChessPiece"/>
public class Pawn : IChessPiece
{
    /// <inheritdoc/>
    public char ToChar() => 'P';
}