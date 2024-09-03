using FizzlePuzzle.ECS.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.ECS;

namespace FizzlePuzzle.ECS.Factories
{
    public static class PuzzleFactory
    {
        public static Entity CreatePuzzle(World world, PuzzleData puzzleData)
        {
            var entity = world.CreateEntity();
            entity.Attach(puzzleData);

            // Calculate total puzzle size and center position
            float totalWidth = (puzzleData.IndividualRects.GetLength(1) * puzzleData.IndividualRects[0, 0].Width * puzzleData.Scale) + ((puzzleData.IndividualRects.GetLength(1) - 1) * puzzleData.Padding);
            float totalHeight = (puzzleData.IndividualRects.GetLength(0) * puzzleData.IndividualRects[0, 0].Height * puzzleData.Scale) + ((puzzleData.IndividualRects.GetLength(0) - 1) * puzzleData.Padding);
            var graphics = SpriteBatchSingleton.Instance.SpriteBatch.GraphicsDevice;
            Vector2 centerPosition = new Vector2(
                (graphics.Viewport.Width - totalWidth) / 2,
                (graphics.Viewport.Height - totalHeight) / 2
            );

            // Create individual puzzle pieces
            for (int y = 0; y < puzzleData.IndividualRects.GetLength(0); y++)
            {
                for (int x = 0; x < puzzleData.IndividualRects.GetLength(1); x++)
                {
                    var piece = puzzleData.IndividualRects[y, x];
                    Vector2 position = new Vector2(
                        centerPosition.X + x * (piece.Width * puzzleData.Scale + puzzleData.Padding),
                        centerPosition.Y + y * (piece.Height * puzzleData.Scale + puzzleData.Padding)
                    );

                    // Calculate base depth
                    float baseDepth = 1f - (position.Y / graphics.Viewport.Height);

                    var pieceEntity = world.CreateEntity();
                    pieceEntity.Attach(new PuzzlePieceComponent(position, new Rectangle((int)position.X, (int)position.Y, piece.Width, piece.Height), baseDepth));
                    puzzleData.PuzzlePieces.Add(pieceEntity);
                }
            }

            return entity;
        }
    }
}