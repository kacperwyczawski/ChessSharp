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