using System.Drawing;
using ChessSharp.Core.BoardRepresentation;

namespace ChessSharp.Core;

public class Player
{
    public AttackDirection AttackDirection { get; }
    public Color Color { get; }
    public string Name { get; }

    public Player(string name, Color color, AttackDirection attackDirection)
    {
        Name = name;
        Color = color;
        AttackDirection = attackDirection;
    }
}