using Microsoft.Xna.Framework;

namespace FizzlePuzzle.ECS.Components
{
    public class PuzzlePieceComponent
    {
        public Vector2 OriginalPosition { get; set; }
        public Vector2 CurrentPosition { get; set; }
        public Rectangle Bounds { get; set; }
        public bool IsSelected { get; set; }
        public float BaseDepth { get; set; }

        public PuzzlePieceComponent(Vector2 position, Rectangle bounds, float baseDepth)
        {
            OriginalPosition = position;
            CurrentPosition = position;
            Bounds = bounds;
            IsSelected = false;
            BaseDepth = baseDepth;
        }
    }
}