using FizzlePuzzle.ECS.Components;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.ECS;
using MonoGame.Extended.ECS.Systems;
using MonoGame.Extended.Graphics;

namespace FizzlePuzzle.ECS.Systems;

public class RenderSystem : EntityDrawSystem
{
    private ComponentMapper<PuzzleComponent> puzzleComponentMapper;
    private GraphicsDevice graphicsDevice;

    public RenderSystem(GraphicsDevice graphicsDevice) : base(Aspect.All(typeof(PuzzleComponent)))
    {
        this.graphicsDevice = graphicsDevice;
    }

    public override void Initialize(IComponentMapperService mapperService)
    {
        puzzleComponentMapper = mapperService.GetMapper<PuzzleComponent>();
    }

    public override void Draw(GameTime gameTime)
    {
        var spriteBatch = SpriteBatchSingleton.Instance.SpriteBatch;
        spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp);

        foreach (var entity in ActiveEntities)
        {
            var puzzle = puzzleComponentMapper.Get(entity);
            var rects = puzzle.IndividualRects;
            float scale = puzzle.Scale;

            int rows = rects.GetLength(0);
            int cols = rects.GetLength(1);

            // Calculate total puzzle size
            float totalWidth = (cols * rects[0, 0].Width * scale) + ((cols - 1) * puzzle.Padding);
            float totalHeight = (rows * rects[0, 0].Height * scale) + ((rows - 1) * puzzle.Padding);

            // Calculate center position
            Vector2 centerPosition = new Vector2(
                (graphicsDevice.Viewport.Width - totalWidth) / 2,
                (graphicsDevice.Viewport.Height - totalHeight) / 2
            );

            for (int y = 0; y < rows; y++)
            {
                for (int x = 0; x < cols; x++)
                {
                    var piece = rects[y, x];
                    Vector2 position = new Vector2(
                        centerPosition.X + x * (piece.Width * scale + puzzle.Padding),
                        centerPosition.Y + y * (piece.Height * scale + puzzle.Padding)
                    );

                    spriteBatch.Draw(
                        piece.Texture,
                        position,
                        piece.Bounds,
                        Color.White,
                        0f,
                        Vector2.Zero,
                        scale,
                        SpriteEffects.None,
                        0f
                    );
                }
            }
        }

        spriteBatch.End();
    }
}