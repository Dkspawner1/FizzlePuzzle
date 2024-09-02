
namespace FizzlePuzzle.ECS.Components;

public class PuzzlePieceComponent
{
    public Vector2 OriginalPosition { get; set; }
    public Vector2 CurrentPosition { get; set; }
    public Rectangle Bounds { get; set; }
    public bool IsSelected { get; set; }

    public PuzzlePieceComponent(Vector2 position, Rectangle bounds)
    {
        OriginalPosition = position;
        CurrentPosition = position;
        Bounds = bounds;
        IsSelected = false;
    }
}