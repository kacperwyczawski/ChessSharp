namespace ConsoleChess;

using ChessPieces;

/// <summary>
/// Represents chess board.
/// </summary>
public partial class ChessBoard
{
    private ChessPiece?[,] chessPiecesArray;

    /// <summary>
    /// Initializes a new instance of the <see cref="ChessBoard"/> class.
    /// </summary>
    /// <param name="initializeEmpty">
    /// Describe if <see cref="ChessBoard"/> would be initialized empty.
    /// </param>
    public ChessBoard(bool initializeEmpty = false)
    {
        this.chessPiecesArray = initializeEmpty ? EmptyChessPiecesArray : StartingChessPiecesArray;
    }
}