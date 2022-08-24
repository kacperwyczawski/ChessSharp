namespace ChessSharp.Core.UnitTests;

using ChessSharp.Core.ChessPieces;
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
    public void UseIndexer()
    {
        // Arrange
        ChessBoard chessBoard = new();
        Knight knight = new(Color.White, chessBoard[1, 1], chessBoard);

        // Act
        chessBoard[3, 3].Piece = knight;
        chessBoard[0, 0].Piece = null;

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(chessBoard[3, 3].Piece, Is.EqualTo(knight));
            Assert.That(chessBoard[0, 0].Piece, Is.EqualTo(null));
            Assert.That(chessBoard[1, 1].Piece, Is.EqualTo(new Pawn(Color.Black, chessBoard[1, 1], chessBoard)));
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
            Assert.That(board[0, 4].Piece, Is.EqualTo(new Pawn(Color.White, board[0, 4], board)));
            
            Assert.That(board[6, 0].Piece, Is.EqualTo(null));
            Assert.That(board[5, 2].Piece, Is.EqualTo(new Knight(Color.Black, board[5, 2], board)));
        });
    }
}