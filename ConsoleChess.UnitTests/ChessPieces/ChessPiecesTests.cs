namespace ConsoleChess.UnitTests.ChessPieces;

using ConsoleChess.ChessPieces;
using System.Drawing;

public class ChessPiecesTests
{
    [Test]
    public void GetChar()
    {
        var pawn = new Pawn(Color.White);
        var knight = new Knight(Color.White);
        var bishop = new Bishop(Color.White);
        var rook = new Rook(Color.White);
        var queen = new Queen(Color.White);
        var king = new King(Color.White);

        Assert.Multiple(() =>
        {
            Assert.That(pawn.ToChar(), Is.EqualTo('P'));
            Assert.That(knight.ToChar(), Is.EqualTo('N'));
            Assert.That(bishop.ToChar(), Is.EqualTo('B'));
            Assert.That(rook.ToChar(), Is.EqualTo('R'));
            Assert.That(queen.ToChar(), Is.EqualTo('Q'));
            Assert.That(king.ToChar(), Is.EqualTo('K'));
        });
    }

    [Test]
    public void GetColor()
    {
        var pawn = new Pawn(Color.White);
        var knight = new Knight(Color.White);
        var bishop = new Bishop(Color.White);
        var rook = new Rook(Color.Black);
        var queen = new Queen(Color.Black);
        var king = new King(Color.Black);

        Assert.Multiple(() =>
        {
            Assert.That(pawn.Color, Is.EqualTo(Color.White));
            Assert.That(knight.Color, Is.EqualTo(Color.White));
            Assert.That(bishop.Color, Is.EqualTo(Color.White));
            Assert.That(rook.Color, Is.EqualTo(Color.Black));
            Assert.That(queen.Color, Is.EqualTo(Color.Black));
            Assert.That(king.Color, Is.EqualTo(Color.Black));
        });
    }

    [Test]
    public void CompareValueEquality()
    {
        var pawn1 = new Pawn(Color.White);
        var pawn2 = new Pawn(Color.Black);
        var pawn3 = new Pawn(Color.White);
        
        Assert.Multiple(() =>
        {
            Assert.That(pawn2, Is.Not.EqualTo(pawn1));
            Assert.That(pawn1, Is.EqualTo(pawn3));
        });
    }
}
