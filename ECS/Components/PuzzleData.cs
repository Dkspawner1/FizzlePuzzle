using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.ECS;
using MonoGame.Extended.Graphics;
using System.Collections.Generic;

namespace FizzlePuzzle.ECS.Components
{
    public class PuzzleData
    {
        public Texture2DRegion[,] IndividualRects { get; }
        public int Padding { get; }
        public float Scale { get; }
        public List<Entity> PuzzlePieces { get; } = new List<Entity>();

        public PuzzleData(Texture2D texture, int rows, int cols, int padding, float scale)
        {
            IndividualRects = new Texture2DRegion[rows, cols];
            Padding = padding;
            Scale = scale;

            // Initialize IndividualRects with subregions of the texture
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
}