using FizzlePuzzle.ECS.Components;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.ECS;
using MonoGame.Extended.ECS.Systems;
using MonoGame.Extended.Graphics;

namespace FizzlePuzzle.ECS.Systems;

public class RenderSystem : EntityDrawSystem
{
    private ComponentMapper<PuzzleComponent> puzzleComponentMapper;
    private ComponentMapper<PuzzlePieceComponent> pieceComponentMapper;

    public RenderSystem() : base(Aspect.All(typeof(PuzzleComponent)))
    {
    }

    public override void Initialize(IComponentMapperService mapperService)
    {
        puzzleComponentMapper = mapperService.GetMapper<PuzzleComponent>();
        pieceComponentMapper = mapperService.GetMapper<PuzzlePieceComponent>();
    }

    public override void Draw(GameTime gameTime)
    {
        var spriteBatch = SpriteBatchSingleton.Instance.SpriteBatch;
        var graphicsDevice = spriteBatch.GraphicsDevice;

        spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp);

        foreach (var entity in ActiveEntities)
        {
            var puzzle = puzzleComponentMapper.Get(entity);
            var rects = puzzle.IndividualRects;
            float scale = puzzle.Scale;

            int rows = rects.GetLength(0);
            int cols = rects.GetLength(1);

            // Calculate total puzzle size and center position
            // ... (keep this part the same)

            for (int i = 0; i < puzzle.PuzzlePieces.Count; i++)
            {
                var pieceEntity = puzzle.PuzzlePieces[i];
                var pieceComponent = pieceComponentMapper.Get(pieceEntity);
                var piece = rects[i / cols, i % cols];

                spriteBatch.Draw(
                    piece.Texture,
                    pieceComponent.CurrentPosition,
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

        spriteBatch.End();
    }
}
