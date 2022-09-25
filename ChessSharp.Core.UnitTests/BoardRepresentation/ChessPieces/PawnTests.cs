using System.Drawing;
using ChessSharp.Core.BoardRepresentation;

namespace ChessSharp.Core.UnitTests.BoardRepresentation.ChessPieces;

public class PawnTests
{
    [Test]
    public void GetValidMoves()
    {
        var game = new ChessGame(csgnString:
            "-- 2P -- -- -- -- -- --;" +
            "-- -- -- -- -- -- -- --;" +
            "-- -- -- -- -- -- -- --;" +
            "-- -- -- -- -- -- -- --;" +
            "-- -- -- -- -- -- -- --;" +
            "-- -- -- -- -- 2P -- --;" +
            "-- -- -- -- -- -- 1P --;" +
            "-- 1P -- -- -- -- -- --;",
            new Player("P1", Color.White, AttackDirection.North),
            new Player("P2", Color.Black, AttackDirection.South));

        // move pawn forward
        game.Board[1, 7].Piece!.GetValidMoves().First(move => move.DestinationCell is { X: 1, Y: 6 }).ExecuteMove();

        Move.Board = game.Board;

        Assert.Multiple(() =>
        {
            Assert.That(game.Board[1, 6].Piece!.GetValidMoves().Single(), Is.EqualTo(
                new Move("1,6 > 1,5 n")));
            Assert.That(game.Board[1, 0].Piece!.GetValidMoves(), Is.EquivalentTo(new List<Move>
            {
                new("1,0 > 1,1 n"),
                new("1,0 > 1,2 n")
            }));
            Assert.That(game.Board[6, 6].Piece!.GetValidMoves(), Is.EquivalentTo(new List<Move>
            {
                new("6,6 > 5,5"),
                new("6,6 > 6,5 n"),
                new("6,6 > 6,4 n")
            }));
            Assert.That(game.Board[5, 5].Piece!.GetValidMoves(), Is.EquivalentTo(new List<Move>
            {
                new("5,5 > 6,6"),
                new("5,5 > 5,6 n"),
                new("5,5 > 5,7 n")
            }));
        });
    }

    [Test]
    public void GetValidMovesEnPassant()
    {
        throw new NotImplementedException();
    }

    [Test]
    public void GetValidMovesHorizontalDirection()
    {
        throw new NotImplementedException();
    }
}