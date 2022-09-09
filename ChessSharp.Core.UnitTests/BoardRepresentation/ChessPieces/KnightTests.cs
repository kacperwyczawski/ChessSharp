using ChessSharp.Core.BoardRepresentation;

namespace ChessSharp.Core.UnitTests.BoardRepresentation.ChessPieces;

[TestFixture]
public class KnightTests
{
    [Test]
    public void GetValidMoves()
    {
        var game = new ChessGame("#Player:P1:White:North;; #Player:P2:Black:West;; #CurrentPlayer:P2;; #Board:8" +
        /* 0 1 2 3 4 5 6 7   */  
        /* k p - - - - - - 0 */  ":P1'sKnight:P2'sPawn:6" +
        /* - p p - k - - - 1 */  ":1:P2'sPawn:P2'sPawn:1:P2'sKnight:3" +
        /* - - - - - - - - 2 */  ":8" +
        /* - - - - - - - - 3 */  ":8" +
        /* - - - - k - - - 4 */  ":4:P1'sKnight:3" +
        /* - - - - - - - - 5 */  ":8" +
        /* - - - - - - - - 6 */  ":8" +
        /* - - - - - - - - 7 */  ":8;;");
        
        Assert.That(game.Board[0, 0].Piece!.GetValidMoves(), Is.EquivalentTo(new List<Move>
        {
            new("0,0 > 2,1"),
            new("0,0 > 1,2"),
            
            new("4,1 > 2,0"),
            new("4,1 > 6,0"),
            new("4,1 > 5,3"),
            new("4,1 > 3,3"),
            new("4,1 > 2,2"),
            new("4,1 > 6,2"),
            
            new("4,4 > 2,3"),
            new("4,4 > 6,3"),
            new("4,4 > 5,6"),
            new("4,4 > 3,6"),
            new("4,4 > 2,5"),
            new("4,4 > 6,5"),
            new("4,4 > 5,2"),
            new("4,4 > 3,2")
        }));
    }
}