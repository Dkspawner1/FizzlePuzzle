using MonoGame.Extended;
using MonoGame.Extended.ECS;
using MonoGame.Extended.Graphics;
using System.Collections.Generic;

namespace FizzlePuzzle.ECS.Components;

public class PuzzleComponent
{
    public Sprite Sprite;
    public Texture2DRegion[,] IndividualRects;
    public int Padding { get; }
    public float Scale { get; }
    public List<Entity> PuzzlePieces { get; } = new List<Entity>();
    public PuzzleComponent(Texture2D texture, int rows, int cols, int padding, float scale)
    {
        Sprite = new Sprite(texture);
        IndividualRects = new Texture2DRegion[rows, cols];
        Padding = padding;
        Scale = scale;

        // Calculate the width and height of each piece with padding
        int pieceWidth = (texture.Width - (padding * (cols - 1))) / cols;
        int pieceHeight = (texture.Height - (padding * (rows - 1))) / rows;

        for (int y = 0; y < rows; y++)
        {
            for (int x = 0; x < cols; x++)
            {
                Rectangle sourceRect = new Rectangle(
                    x * (pieceWidth + padding),
                    y * (pieceHeight + padding),
                    pieceWidth,
                    pieceHeight
                );

                IndividualRects[y, x] = new Texture2DRegion(texture, sourceRect);
            }
        }
    }
}