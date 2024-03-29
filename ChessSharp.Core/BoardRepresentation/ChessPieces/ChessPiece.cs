﻿namespace ChessSharp.Core.BoardRepresentation.ChessPieces;

/// <summary>
/// Represents single chess piece.
/// </summary>
public abstract class ChessPiece
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ChessPiece"/> class.
    /// </summary>
    /// <param name="position">
    /// Cell on which chess piece is placed.
    /// </param>
    /// <param name="parentBoard">
    /// Board on which chess piece is located.
    /// </param>
    /// <param name="player">
    /// Player who owns chess piece.
    /// </param>
    public ChessPiece(Cell position, ChessBoard parentBoard, Player player)
    {
        Position = position;
        ParentBoard = parentBoard;
        Player = player;
    }
    
    /// <summary>
    /// Player who owns chess piece.
    /// </summary>
    public Player Player { get; }
    
    
    /// <summary>
    /// Gets or sets cell on which chess piece is located.
    /// </summary>
    public Cell Position { get; set; }
    
    /// <summary>
    /// Indicates whether chess piece has moved or not.
    /// </summary>
    public bool HasMoved { get; set; }

    /// <summary>
    /// Gets board on which chess piece is located.
    /// </summary>
    public ChessBoard ParentBoard { get; }

    /// <summary>
    /// Converts chess piece to it's <see cref="char"/> representation.
    /// </summary>
    /// <returns>
    /// The <see cref="char"/> representation of object.
    /// </returns>
    public abstract char ToChar();
    
    public abstract IEnumerable<Move> GetValidMoves ();
}