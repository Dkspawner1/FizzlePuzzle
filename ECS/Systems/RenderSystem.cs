using FizzlePuzzle.ECS.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.ECS;
using MonoGame.Extended.ECS.Systems;

namespace FizzlePuzzle.ECS.Systems
{
    public class RenderSystem : EntityDrawSystem
    {
        private ComponentMapper<PuzzleData> puzzleDataMapper;
        private ComponentMapper<PuzzlePieceComponent> pieceComponentMapper;

        public RenderSystem() : base(Aspect.All(typeof(PuzzleData)))
        {
        }

        public override void Initialize(IComponentMapperService mapperService)
        {
            puzzleDataMapper = mapperService.GetMapper<PuzzleData>();
            pieceComponentMapper = mapperService.GetMapper<PuzzlePieceComponent>();
        }

        public override void Draw(GameTime gameTime)
        {
            var spriteBatch = SpriteBatchSingleton.Instance.SpriteBatch;
            var graphicsDevice = spriteBatch.GraphicsDevice;

            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend, SamplerState.PointClamp);

            foreach (var puzzleEntity in ActiveEntities)
            {
                var puzzleData = puzzleDataMapper.Get(puzzleEntity);
                var rects = puzzleData.IndividualRects;
                float scale = puzzleData.Scale;

                for (int i = 0; i < puzzleData.PuzzlePieces.Count; i++)
                {
                    var pieceEntity = puzzleData.PuzzlePieces[i];
                    var pieceComponent = pieceComponentMapper.Get(pieceEntity);
                    var piece = rects[i / rects.GetLength(1), i % rects.GetLength(1)];

                    float depth = pieceComponent.IsSelected ? 0f : pieceComponent.BaseDepth;

                    spriteBatch.Draw(
                        piece.Texture,
                        pieceComponent.CurrentPosition,
                        piece.Bounds,
                        Color.White,
                        0f,
                        Vector2.Zero,
                        scale,
                        SpriteEffects.None,
                        depth
                    );
                }
            }

            spriteBatch.End();
        }
    }
}