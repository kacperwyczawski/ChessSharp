namespace ConsoleChess;

using ChessPieces;

/// <summary>
/// Represents chess board.
/// </summary>
public partial class ChessBoard
{
    private IChessPiece?[,] chessPiecesArray = StartingChessPiecesArray;
}