using System.Drawing;
using ChessSharp.Core.BoardRepresentation;

namespace ChessSharp.Core.UnitTests.BoardRepresentation.ChessPieces;

public class BishopTests
{
    [Test]
    public void GetValidMoves()
    {
        var game = new ChessGame(csgnString:
            "1B -- -- -- -- -- -- 2B;" +
            "-- 1P -- -- -- -- 1P --;" +
            "-- -- -- -- -- -- -- --;" +
            "-- -- -- -- -- -- -- --;" +
            "-- -- -- -- -- -- -- --;" +
            "-- -- -- -- -- -- -- --;" +
            "-- -- -- -- -- -- 2B --;" +
            "-- -- -- -- -- -- -- --;",
            new Player("P1", Color.White, AttackDirection.North),
            new Player("P2", Color.Black, AttackDirection.South));

        Move.Board = game.Board;

        Assert.That(game.Board[0, 0].Piece!.GetValidMoves(), Is.Empty);
        Assert.That(game.Board[7, 0].Piece!.GetValidMoves().Single(), Is.EqualTo(new Move("7,0 > 6,1")));
        Assert.That(game.Board[6, 6].Piece!.GetValidMoves(), Is.EquivalentTo(new List<Move>
        {
            new("6,6 > 5,5"),
            new("6,6 > 4,4"),
            new("6,6 > 3,3"),
            new("6,6 > 2,2"),
            new("6,6 > 1,1"),

            new("6,6 > 5,7"),
            new("6,6 > 7,5"),
            new("6,6 > 7,7")
        }));
    }
}