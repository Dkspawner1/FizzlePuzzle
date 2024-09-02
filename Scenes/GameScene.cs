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
        var puzzleComponent = new PuzzleComponent(ContentLoaderSingleton.Instance.Load<Texture2D>("Textures/fizzle"), 5, 5, 3, 1f);
        var puzzle = new Puzzle(world, puzzleComponent);

        // Create individual puzzle pieces
        for (int y = 0; y < puzzleComponent.IndividualRects.GetLength(0); y++)
        {
            for (int x = 0; x < puzzleComponent.IndividualRects.GetLength(1); x++)
            {
                var piece = puzzleComponent.IndividualRects[y, x];
                Vector2 position = new Vector2(
                    x * (piece.Width * puzzleComponent.Scale + puzzleComponent.Padding),
                    y * (piece.Height * puzzleComponent.Scale + puzzleComponent.Padding)
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
