namespace ConsoleChess;

using ChessPieces;

/// <content>
/// This part of the <see cref="ChessBoard"/> contains a set of useful <see cref="IChessPiece"/> arrays.
/// </content>
public partial class ChessBoard
{
    private static readonly IChessPiece?[,] StartingChessPiecesArray = new IChessPiece?[8, 8]
    {
        { new Rook(), new Knight(), new Bishop(), new Queen(), new King(), new Bishop(), new Knight(), new Rook() },
        { new Pawn(), new Pawn(), new Pawn(), new Pawn(), new Pawn(), new Pawn(), new Pawn(), new Pawn() },
        { null, null, null, null, null, null, null, null, },
        { null, null, null, null, null, null, null, null, },
        { null, null, null, null, null, null, null, null, },
        { null, null, null, null, null, null, null, null, },
        { new Pawn(), new Pawn(), new Pawn(), new Pawn(), new Pawn(), new Pawn(), new Pawn(), new Pawn() },
        { new Rook(), new Knight(), new Bishop(), new Queen(), new King(), new Bishop(), new Knight(), new Rook() },
    };

    private static readonly IChessPiece?[,] EmptyChessPiecesArray = new IChessPiece?[8, 8]
    {
        { null, null, null, null, null, null, null, null, },
        { null, null, null, null, null, null, null, null, },
        { null, null, null, null, null, null, null, null, },
        { null, null, null, null, null, null, null, null, },
        { null, null, null, null, null, null, null, null, },
        { null, null, null, null, null, null, null, null, },
        { null, null, null, null, null, null, null, null, },
        { null, null, null, null, null, null, null, null, },
    };
}