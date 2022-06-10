namespace ConsoleChess.UnitTests.ChessPieces;
using ConsoleChess.ChessPieces;

public class ChessPiecesTests
{
    [Test]
    public void GetChar()
    {
        var pawn = new Pawn();
        var knight = new Knight();
        var bishop = new Bishop();
        var rook = new Rook();
        var queen = new Queen();
        var king = new King();

        Assert.That(pawn.ToChar(), Is.EqualTo('P'));
        Assert.That(knight.ToChar(), Is.EqualTo('N'));
        Assert.That(bishop.ToChar(), Is.EqualTo('B'));
        Assert.That(rook.ToChar(), Is.EqualTo('R'));
        Assert.That(queen.ToChar(), Is.EqualTo('Q'));
        Assert.That(king.ToChar(), Is.EqualTo('K'));
    }
}
