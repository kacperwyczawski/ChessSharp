using System.Text.RegularExpressions;

namespace ConsoleChess;

/// <summary>
/// represents a valid move for a piece
/// important: move should be always valid, no need to check if move is valid
/// </summary>
public readonly struct Move
{
    public readonly Cell DestinationCell;
    
    private readonly Cell _sourceCell;
    
    private readonly Cell _captureCell;
    
    public bool IsCapture => _captureCell.IsOccupied;
    
    /// <summary>
    /// Initializes a new instance of the <see cref="Move"/> struct.
    /// </summary>
    /// <param name="destinationCell">
    /// cell on which piece is moving
    /// </param>
    /// <param name="sourceCell">
    /// cell from which piece is moving
    /// </param>
    /// <param name="captureCell">
    /// cell on which piece is captured (if null or not specified, capture is on destination cell)
    /// </param>
    public Move(Cell destinationCell, Cell sourceCell, Cell? captureCell = null)
    {
        DestinationCell = destinationCell;
        _sourceCell = sourceCell;
        _captureCell = captureCell ?? destinationCell;
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
    /// <param name="board">
    /// board on which move is performed
    /// has to be provided to get cells
    /// </param>
    public Move(string moveString, ChessBoard board)
    {
        // regex for move string
        // can be: "n,n > n,n x n,n" or "n,n > n,n"
        // where n is number between 0 and 7
        // spaces are optional
        var regex = new Regex(@"^(?<source>[0-7],[0-7])" // n,n (source cell)
                              + @"\s?>\s?" // > (optionally surrounded by spaces)
                              + @"(?<destination>[0-7],[0-7])" // n,n (destination cell)
                              + @"\s?x\s?" // x (optionally surrounded by spaces)
                              + @"(?<capture>[0-7],[0-7])?$"); // n,n (capture cell)
        
        var match = regex.Match(moveString);
        
        // throw exception if move string is invalid
        if (!match.Success)
            throw new ArgumentException("Invalid move string", nameof(moveString));
        
        var sourceCell = board[
            int.Parse(match.Groups["source"].Value[0].ToString()),
            int.Parse(match.Groups["source"].Value[2].ToString())];
        var destinationCell = board[
            int.Parse(match.Groups["destination"].Value[0].ToString()),
            int.Parse(match.Groups["destination"].Value[2].ToString())];
        var captureCell = match.Groups["capture"].Success
            ? board[
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