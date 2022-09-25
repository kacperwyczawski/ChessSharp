using System.Text.RegularExpressions;

namespace ChessSharp.Core.BoardRepresentation;

/// <summary>
/// represents a valid move for a piece
/// important: move should be always valid, no need to check if move is valid
/// </summary>
public readonly struct Move
{
    public readonly Cell DestinationCell;

    public static ChessBoard? Board = null;

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
        if (sourceCell.IsOccupied == false)
            throw new ArgumentException("Source cell have to have a piece on it", nameof(sourceCell));

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
        if (sourceCell.IsOccupied == false)
            throw new ArgumentException("Source cell have to have a piece on it", nameof(sourceCell));

        DestinationCell = destinationCell;
        _sourceCell = sourceCell;
        _captureCell = captureCell;
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="Move"/> struct using ChessSharpMoveNotation (CSMN).
    /// </summary>
    /// <param name="moveString">
    ///     string representation of move in CSMN system. Spaces are ignored<br/>
    ///     Remember that almost all moves should have capture cell, except for example regular pawn move<br/>
    ///     <c>"1,2 > 1,4 x 1,3"</c> - move piece from cell 1,2 to 1,4 and capture piece on 1,3<br/>
    ///     capture piece can be omitted if it is on destination cell, like this:<br/>
    ///     <c>"1,2 > 1,4"</c> - move piece from cell 1,2 to 1,4 and capture piece on 1,4<br/>
    ///     if move doesn't have capture cell, for example regular pawn move, then do it like this:<br/>
    ///     <c>"1,2 > 1,4 n"</c> - move piece from cell 1,2 to 1,4 without capture cell<br/>
    /// </param>
    public Move(string moveString)
    {
        if (Board == null)
            throw new ArgumentException
                ($"You have to set {nameof(Board)} property before creating moves with this constructor");

        // regex for move string
        // can be:
        // [1] "a,a > a,a x a,a"
        // [2] "a,a > a,a"
        // [3] "a,a > a,a n"
        // where a is number between 0 and 7

        // remove whitespaces from string
        moveString = Regex.Replace(moveString, @"\s+", "");

        // match case [1] "a,a > a,a x a,a"
        var regex1 = new Regex(@"^(?<source>[0-7],[0-7])"
                               + @">"
                               + @"(?<destination>[0-7],[0-7])"
                               + @"x"
                               + @"(?<capture>[0-7],[0-7])$");

        var match1 = regex1.Match(moveString);

        // match case [2] "a,a > a,a"
        var regex2 = new Regex(@"^(?<source>[0-7],[0-7])"
                               + @">"
                               + @"(?<destination>[0-7],[0-7])$");

        var match2 = regex2.Match(moveString);

        // match case [3] "a,a > a,a n"
        var regex3 = new Regex(@"^(?<source>[0-7],[0-7])"
                               + @">"
                               + @"(?<destination>[0-7],[0-7])"
                               + @"n$");

        var match3 = regex3.Match(moveString);

        if (match1.Success)
        {
            DestinationCell = Board[
                int.Parse(match1.Groups["destination"].Value[0].ToString()),
                int.Parse(match1.Groups["destination"].Value[2].ToString())];
            _sourceCell = Board[
                int.Parse(match1.Groups["source"].Value[0].ToString()),
                int.Parse(match1.Groups["source"].Value[2].ToString())];
            _captureCell = Board[
                int.Parse(match1.Groups["capture"].Value[0].ToString()),
                int.Parse(match1.Groups["capture"].Value[2].ToString())];
        }
        else if (match2.Success)
        {
            DestinationCell = Board[
                int.Parse(match2.Groups["destination"].Value[0].ToString()),
                int.Parse(match2.Groups["destination"].Value[2].ToString())];
            _sourceCell = Board[
                int.Parse(match2.Groups["source"].Value[0].ToString()),
                int.Parse(match2.Groups["source"].Value[2].ToString())];
            _captureCell = DestinationCell;
        }
        else if (match3.Success)
        {
            DestinationCell = Board[
                int.Parse(match3.Groups["destination"].Value[0].ToString()),
                int.Parse(match3.Groups["destination"].Value[2].ToString())];
            _sourceCell = Board[
                int.Parse(match3.Groups["source"].Value[0].ToString()),
                int.Parse(match3.Groups["source"].Value[2].ToString())];
            _captureCell = null;
        }
        else
        {
            throw new ArgumentException("Invalid move string", nameof(moveString));
        }
    }

    public void ExecuteMove()
    {
        // set HasMoved to true for piece on source cell
        _sourceCell.Piece!.HasMoved = true;
        
        // change piece's position
        _sourceCell.Piece.Position = DestinationCell;

        // If there is a capture cell, remove piece from capture cell
        _captureCell?.RemovePiece();

        // Move piece to destination
        DestinationCell.Piece = _sourceCell.Piece;

        // Remove piece from source
        _sourceCell.RemovePiece();
        
        // TODO: Log move in board history or something, idk
    }

    public override string ToString() => _captureCell is null
        ? $"[{_sourceCell} > {DestinationCell} n]"
        : $"[{_sourceCell} > {DestinationCell} x {_captureCell}]";
}