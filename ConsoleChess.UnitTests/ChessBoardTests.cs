namespace ConsoleChess.UnitTests;

using ConsoleChess.ChessPieces;
using System.Drawing;

public class ChessBoardTests
{
    [Test]
    public void CreateInstanceWithStartingBoard()
    {
        ChessBoard chessBoard = new();

        var expectedArray = new char?[,]
        {
            { 'R', 'N', 'B', 'Q', 'K', 'B', 'N', 'R' },
            { 'P', 'P', 'P', 'P', 'P', 'P', 'P', 'P' },
            { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
            { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
            { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
            { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
            { 'P', 'P', 'P', 'P', 'P', 'P', 'P', 'P' },
            { 'R', 'N', 'B', 'Q', 'K', 'B', 'N', 'R' }
        };
        Assert.That(chessBoard.ToCharArray(), Is.EqualTo(expectedArray));
    }

    [Test]
    public void ConvertToChessPiecesArray()
    {
        ChessBoard chessBoard = new();

        var expectedArray = new ChessPiece?[,]
        {
            {
                new Rook(Color.Black), new Knight(Color.Black), new Bishop(Color.Black), new Queen(Color.Black),
                new King(Color.Black), new Bishop(Color.Black), new Knight(Color.Black), new Rook(Color.Black)
            },
            {
                new Pawn(Color.Black), new Pawn(Color.Black), new Pawn(Color.Black), new Pawn(Color.Black),
                new Pawn(Color.Black), new Pawn(Color.Black), new Pawn(Color.Black), new Pawn(Color.Black)
            },
            { null, null, null, null, null, null, null, null },
            { null, null, null, null, null, null, null, null },
            { null, null, null, null, null, null, null, null },
            { null, null, null, null, null, null, null, null },
            {
                new Pawn(Color.White), new Pawn(Color.White), new Pawn(Color.White), new Pawn(Color.White),
                new Pawn(Color.White), new Pawn(Color.White), new Pawn(Color.White), new Pawn(Color.White)
            },
            {
                new Rook(Color.White), new Knight(Color.White), new Bishop(Color.White), new Queen(Color.White),
                new King(Color.White), new Bishop(Color.White), new Knight(Color.White), new Rook(Color.White)
            }
        };
        var actualArray = chessBoard.ToChessPiecesArray();

        Assert.That(actualArray, Is.EqualTo(expectedArray));
    }

    [Test]
    public void UseIndexer()
    {
        // Arrange
        ChessBoard chessBoard = new();
        Knight knight = new(Color.White);

        // Act
        chessBoard[3, 3].Piece = knight;
        chessBoard[0, 0].Piece = null;

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(chessBoard[3, 3].Piece, Is.EqualTo(knight));
            Assert.That(chessBoard[0, 0].Piece, Is.EqualTo(null));
            Assert.That(chessBoard[1, 1].Piece, Is.EqualTo(new Pawn(Color.Black)));
        });
    }

    [Test]
    public void MovePiece()
    {
        // Arrange
        ChessBoard board = new();
        
        // Act
        board.MovePiece(board[0, 6], board[0, 4]);
        board.MovePiece(board[6, 0], board[5, 2]);
        
        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(board[0, 6].Piece, Is.EqualTo(null));
            Assert.That(board[0, 4].Piece, Is.EqualTo(new Pawn(Color.White)));
            
            Assert.That(board[6, 0].Piece, Is.EqualTo(null));
            Assert.That(board[5, 2].Piece, Is.EqualTo(new Knight(Color.Black)));
        });
    }
}