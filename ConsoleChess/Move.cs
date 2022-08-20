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
    ///     Initializes a new instance of the <see cref="Move"/> struct.
    /// </summary>
    /// <param name="moveString">
    ///     string representation of move. Spaces are optional
    ///     <example>
    ///         Remember that almost all moves should have capture cell, except for example regular pawn move<br/>
    ///         <c>"1,2 > 1,4 x 1,3"</c> - move piece from cell 1,2 to 1,4 and capture piece on 1,3<br/>
    ///         capture piece can be omitted if it is on destination cell, like this:<br/>
    ///         <c>"1,2 > 1,4"</c> - move piece from cell 1,2 to 1,4 and capture piece on 1,4<br/>
    ///         if move doesn't have capture cell, for example regular pawn move, then do it like this:<br/>
    ///         <c>"1,2 > 1,4 n"</c> - move piece from cell 1,2 to 1,4 without capture cell<br/>
    ///     </example>
    /// </param>
    public Move(string moveString)
    {
        if (Board == null)
            throw new ArgumentException($"You have to set {nameof(Board)} " +
                                        "property before creating moves with this constructor");

        // regex for move string
        // can be:
        // [1] "a,a > a,a x a,a"
        // [2] "a,a > a,a"
        // [3] "a,a > a,a n"
        // where a is number between 0 and 7
        
        // also this regex match [4] "a,a > a,a n a,a" but last cell is anyway ignored.
        // Why? I don't know how to write proper regex.
        var regex = new Regex(@"^(?<source>[0-7],[0-7])" // a,a (source cell)
                              + @"\s?>\s?" // > (optionally surrounded by spaces)
                              + @"(?<destination>[0-7],[0-7])" 
                              + @"\s?" // optional space
                              + @"(?<have-capture-cell>[xn])?" // x or n (determine if there is capture cell)(optional)
                              + @"\s?" // optional space
                              + @"(?<capture>[0-7],[0-7])?$"); // a,a (capture cell)(optional)

        var match = regex.Match(moveString);

        // throw exception if move string is invalid
        if (!match.Success)
            throw new ArgumentException("Invalid move string", nameof(moveString));

        // ✨ and here is over complicated way to get values from match ✨
        var sourceCell = Board[
            int.Parse(match.Groups["source"].Value[0].ToString()),
            int.Parse(match.Groups["source"].Value[2].ToString())];
        
        var destinationCell = Board[
            int.Parse(match.Groups["destination"].Value[0].ToString()),
            int.Parse(match.Groups["destination"].Value[2].ToString())];

        Cell? captureCell;
        if (match.Groups["have-capture-cell"].Success) // option [1] or [3] or [4]
        {
            if (match.Groups["have-capture-cell"].Value == "x") // option [1]
            {
                captureCell = Board[
                    int.Parse(match.Groups["capture"].Value[0].ToString()),
                    int.Parse(match.Groups["capture"].Value[2].ToString())];
            }
            else // option [3] or [4]
            {
                captureCell = null;
            }
        }
        else // option [2]
        {
            captureCell = destinationCell;
        }

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

        // If there is a capture cell, remove piece from capture cell
        _captureCell?.RemovePiece();
    }
}