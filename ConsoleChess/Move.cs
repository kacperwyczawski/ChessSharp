using System.Text.RegularExpressions;

namespace ConsoleChess;

/// <summary>
/// represents a valid move for a piece
/// important: move should be always valid, no need to check if move is valid
/// </summary>
public readonly struct Move
{
    public readonly Cell DestinationCell;

    public static readonly ChessBoard? Board = null;

    private readonly Cell _sourceCell;

    private readonly Cell? _captureCell;

    public bool IsCapture => _captureCell?.IsOccupied ?? false;

    /// <summary>
    /// Initializes a new instance of the <see cref="Move"/> struct.
    /// This constructor is recommended for most cases.
    /// </summary>
    /// <param name="destinationAndCaptureCell">
    /// cell on which piece is moving and cell on which enemy piece is captured
    /// </param>
    /// <param name="sourceCell">
    /// cell from which piece is moving
    /// </param>
    public Move(Cell destinationAndCaptureCell, Cell sourceCell)
    {
        _sourceCell = sourceCell;
        _captureCell = DestinationCell = destinationAndCaptureCell;
    }
    
    /// <summary>
    /// Initializes a new instance of the <see cref="Move"/> struct.
    /// This constructor is recommended for specific cases
    /// when move doesn't have a capture cell or it is not in destination.
    /// </summary>
    /// <param name="destinationCell">
    /// cell on which piece is moving
    /// </param>
    /// <param name="sourceCell">
    /// cell from which piece is moving
    /// </param>
    /// <param name="captureCell">
    /// cell on which enemy piece is captured
    /// (if null, then no capture but remember that even move to empty cell have it's capture cell)
    /// (null here is used for example when pawn is moving forward without capture)
    /// </param>
    public Move(Cell destinationCell, Cell sourceCell, Cell? captureCell)
    {
        DestinationCell = destinationCell;
        _sourceCell = sourceCell;
        _captureCell = captureCell;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Move"/> struct.
    /// </summary>
    /// <param name="moveString">
    /// string representation of move, for example:
    /// "1,2 > 1,4 x 1,3" - move piece from cell 1,2 to 1,4 and capture piece on 1,3
    /// capture piece can be omitted if it is on destination cell, like this:
    /// "1,2 > 1,4" - move piece from cell 1,2 to 1,4 and capture piece on 1,4
    /// note: spaces are optional
    /// </param>
    public Move(string moveString)
    {
        if (Board == null)
            throw new ArgumentException($"You have to set {nameof(Board)} " +
                                        "property before creating moves with this constructor");

        // regex for move string
        // can be: "n,n > n,n x n,n" or "n,n > n,n"
        // where n is number between 0 and 7
        // spaces are optional
        var regex = new Regex(@"^(?<source>[0-7],[0-7])" // n,n (source cell)
                              + @"\s?>\s?" // > (optionally surrounded by spaces)
                              + @"(?<destination>[0-7],[0-7])" // n,n (destination cell)
                              + @"\s?x\s?" // x (optionally surrounded by spaces)
                              + @"(?<capture>[0-7],[0-7])?$"); // n,n (capture cell)(optional)

        var match = regex.Match(moveString);

        // throw exception if move string is invalid
        if (!match.Success)
            throw new ArgumentException("Invalid move string", nameof(moveString));

        var sourceCell = Board[
            int.Parse(match.Groups["source"].Value[0].ToString()),
            int.Parse(match.Groups["source"].Value[2].ToString())];
        var destinationCell = Board[
            int.Parse(match.Groups["destination"].Value[0].ToString()),
            int.Parse(match.Groups["destination"].Value[2].ToString())];
        var captureCell = match.Groups["capture"].Success
            ? Board[
                int.Parse(match.Groups["capture"].Value[0].ToString()),
                int.Parse(match.Groups["capture"].Value[2].ToString())]
            : destinationCell;

        DestinationCell = destinationCell;
        _sourceCell = sourceCell;
        _captureCell = captureCell;
    }

    public void ExecuteMove()
    {
        // Move piece to destination
        DestinationCell.Piece = _sourceCell.Piece;

        // Remove piece from source
        _sourceCell.Piece = null;

        // If there is a capture, remove the captured piece
        _captureCell.RemovePiece();
    }
}