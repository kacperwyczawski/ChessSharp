namespace ConsoleChess.UnitTests.ChessPieces;
using ConsoleChess.ChessPieces;

public class PawnTests
{
    [Test]
    public void GetChar()
    {
        var pawn = new Pawn();

        Assert.That(pawn.ToChar(), Is.EqualTo('P'));

    }
}
