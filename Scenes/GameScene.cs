using FizzlePuzzle.ECS.Components;
using FizzlePuzzle.ECS.Entities;
using FizzlePuzzle.ECS.Systems;
using MonoGame.Extended.ECS.Systems;
using MonoGame.Extended.Graphics;

namespace FizzlePuzzle.Scenes;

public class GameScene : SceneBase
{
    public GameScene() : 
        base([
        new RenderSystem(),
        new PuzzleInputSystem()])
    {

    }
    public override void Initialize()
    {
    }

    public override void LoadContent()
    {
        var puzzleComponent = new PuzzleComponent(ContentLoaderSingleton.Instance.Load<Texture2D>("Textures/landscape-0"), 10, 10, 5, 0.8f);
        var puzzle = new Puzzle(world, puzzleComponent);

        // Calculate total puzzle size
        float totalWidth = (puzzleComponent.IndividualRects.GetLength(1) * puzzleComponent.IndividualRects[0, 0].Width * puzzleComponent.Scale) + ((puzzleComponent.IndividualRects.GetLength(1) - 1) * puzzleComponent.Padding);
        float totalHeight = (puzzleComponent.IndividualRects.GetLength(0) * puzzleComponent.IndividualRects[0, 0].Height * puzzleComponent.Scale) + ((puzzleComponent.IndividualRects.GetLength(0) - 1) * puzzleComponent.Padding);
        var graphics = SpriteBatchSingleton.Instance.SpriteBatch.GraphicsDevice;
        // Calculate center position
        Vector2 centerPosition = new Vector2(
            (graphics.Viewport.Width - totalWidth) / 2,
            (graphics.Viewport.Height - totalHeight) / 2
        );

        // Create individual puzzle pieces
        for (int y = 0; y < puzzleComponent.IndividualRects.GetLength(0); y++)
        {
            for (int x = 0; x < puzzleComponent.IndividualRects.GetLength(1); x++)
            {
                var piece = puzzleComponent.IndividualRects[y, x];
                Vector2 position = new Vector2(
                    centerPosition.X + x * (piece.Width * puzzleComponent.Scale + puzzleComponent.Padding),
                    centerPosition.Y + y * (piece.Height * puzzleComponent.Scale + puzzleComponent.Padding)
                );
                var pieceEntity = world.CreateEntity();
                pieceEntity.Attach(new PuzzlePieceComponent(position, new Rectangle((int)position.X, (int)position.Y, piece.Width, piece.Height)));
                puzzleComponent.PuzzlePieces.Add(pieceEntity);
            }
        }
    }
    public override void UnloadContent()
    {
        ContentLoaderSingleton.Instance.UnloadAll();
    }
    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);
    }
    public override void Draw(GameTime gameTime)
    {


        base.Draw(gameTime);
    }


}
