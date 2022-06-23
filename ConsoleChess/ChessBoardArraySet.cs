namespace ConsoleChess;

using ChessPieces;
using System.Drawing;

/// <content>
/// This part of the <see cref="ChessBoard"/> contains a set of useful <see cref="IChessPiece"/> arrays.
/// </content>
public partial class ChessBoard
{
    private static readonly IChessPiece?[,] StartingChessPiecesArray = new IChessPiece?[8, 8]
    {
        { new Rook(Color.Black), new Knight(Color.Black), new Bishop(Color.Black), new Queen(Color.Black), new King(Color.Black), new Bishop(Color.Black), new Knight(Color.Black), new Rook(Color.Black) },
        { new Pawn(Color.Black), new Pawn(Color.Black), new Pawn(Color.Black), new Pawn(Color.Black), new Pawn(Color.Black), new Pawn(Color.Black), new Pawn(Color.Black), new Pawn(Color.Black) },
        { null, null, null, null, null, null, null, null, },
        { null, null, null, null, null, null, null, null, },
        { null, null, null, null, null, null, null, null, },
        { null, null, null, null, null, null, null, null, },
        { new Pawn(Color.White), new Pawn(Color.White), new Pawn(Color.White), new Pawn(Color.White), new Pawn(Color.White), new Pawn(Color.White), new Pawn(Color.White), new Pawn(Color.White) },
        { new Rook(Color.White), new Knight(Color.White), new Bishop(Color.White), new Queen(Color.White), new King(Color.White), new Bishop(Color.White), new Knight(Color.White), new Rook(Color.White) },
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