namespace ConsoleChess.UnitTests;

using ConsoleChess.ChessPieces;
using System.Drawing;

public class ChessBoardTests
{
    [Test]
    public void CreateInstanceWithEmptyBoard()
    {
        ChessBoard chessBoard = new(true);

        var expectedArray = new char?[8, 8];
        Assert.That(chessBoard.ToCharArray, Is.EqualTo(expectedArray));
    }

    [Test]
    public void CreateInstanceWithStartingBoard()
    {
        ChessBoard chessBoard = new();

        var expectedArray = new char?[8, 8]
        {
            { 'R', 'N', 'B', 'Q', 'K', 'B', 'N', 'R' },
            { 'P', 'P', 'P', 'P', 'P', 'P', 'P', 'P' },
            { null, null, null, null, null, null, null, null },
            { null, null, null, null, null, null, null, null },
            { null, null, null, null, null, null, null, null },
            { null, null, null, null, null, null, null, null },
            { 'P', 'P', 'P', 'P', 'P', 'P', 'P', 'P' },
            { 'R', 'N', 'B', 'Q', 'K', 'B', 'N', 'R' }
        };
        Assert.That(chessBoard.ToCharArray(), Is.EqualTo(expectedArray));
    }

    [Test]
    public void ConvertToChessPiecesArray()
    {
        ChessBoard chessBoard = new();

        var expectedArray = new ChessPiece?[8, 8]
        {
            {
                new Rook(Color.Black), new Knight(Color.Black), new Bishop(Color.Black), new Queen(Color.Black),
                new King(Color.Black), new Bishop(Color.Black), new Knight(Color.Black), new Rook(Color.Black)
            },
            {
                new Pawn(Color.Black), new Pawn(Color.Black), new Pawn(Color.Black), new Pawn(Color.Black),
                new Pawn(Color.Black), new Pawn(Color.Black), new Pawn(Color.Black), new Pawn(Color.Black)
            },
            { null, null, null, null, null, null, null, null, },
            { null, null, null, null, null, null, null, null, },
            { null, null, null, null, null, null, null, null, },
            { null, null, null, null, null, null, null, null, },
            {
                new Pawn(Color.White), new Pawn(Color.White), new Pawn(Color.White), new Pawn(Color.White),
                new Pawn(Color.White), new Pawn(Color.White), new Pawn(Color.White), new Pawn(Color.White)
            },
            {
                new Rook(Color.White), new Knight(Color.White), new Bishop(Color.White), new Queen(Color.White),
                new King(Color.White), new Bishop(Color.White), new Knight(Color.White), new Rook(Color.White)
            },
        };
        var actualArray = chessBoard.ToArray();

        Assert.That(actualArray, Is.EqualTo(expectedArray));
    }

    [Test]
    public void UseIndexer()
    {
        // Arrange
        ChessBoard chessBoard = new();
        Knight knight = new(Color.White);

        // Act
        chessBoard[3, 3] = knight;
        chessBoard[0, 0] = null;

        // Assert
        Assert.That(chessBoard[3, 3], Is.EqualTo(knight));
        Assert.That(chessBoard[0, 0], Is.EqualTo(null));
        Assert.That(chessBoard[1, 1], Is.EqualTo(new Pawn(Color.Black)));
    }
}