namespace ConsoleChess;

/// <summary>
/// represents a valid move for a piece
/// important: move should be always valid, no need to check if move is valid
/// </summary>
/// <param name="Destination">
/// cell on which piece is moving
/// </param>
/// <param name="Source">
/// cell from which piece is moving
/// </param>
/// <param name="Capture">
/// cell on which piece is captured (if any)
/// </param>
public readonly record struct Move(Cell Destination, Cell Source, Cell? Capture)
{
    public bool IsCapture => Capture is not null;
    public void ExecuteMove()
    {
        // Move piece to destination
        Destination.Piece = Source.Piece;
        
        // Remove piece from source
        Source.Piece = null;
        
        // If there is a capture, remove the captured piece
        Capture?.RemovePiece();
    }
}