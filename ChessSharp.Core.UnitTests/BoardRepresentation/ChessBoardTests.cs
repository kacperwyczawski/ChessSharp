using System.Drawing;
using ChessSharp.Core.BoardRepresentation;
using ChessSharp.Core.BoardRepresentation.ChessPieces;

namespace ChessSharp.Core.UnitTests.BoardRepresentation;

public class ChessBoardTests
{
    [Test]
    public void UseIndexer()
    {
        var p1 = new Player("P1", Color.Blue, AttackDirection.North);
        var p2 = new Player("P2", Color.Red, AttackDirection.South);
        
        var board = new ChessBoard(p1, p2);
        
        var piece = board[0, 0].Piece;
        var pawn = new Pawn(board[3, 3], board, p1);
        
        Assert.Multiple(() =>
        {
            Assert.That(board[0, 0].Piece, Is.EqualTo(piece));
            Assert.That(board[3, 3].Piece, Is.EqualTo(pawn));
            Assert.That(board[3, 4].Piece, Is.Null);
        });
    }
}