using FizzlePuzzle.ECS.Components;
using FizzlePuzzle.ECS.Entities;
using FizzlePuzzle.ECS.Systems;
using MonoGame.Extended.Graphics;

namespace FizzlePuzzle.Scenes;

public class GameScene : SceneBase
{
    public GameScene() : base(new[] { new RenderSystem(SpriteBatchSingleton.Instance.SpriteBatch.GraphicsDevice) })
    {

    }
    public override void Initialize()
    {
    }

    public override void LoadContent()
    {

        var puzzleComponent = new PuzzleComponent(ContentLoaderSingleton.Instance.Load<Texture2D>("Textures/fizzle"), 5, 5, 3, 1f);
        var puzzle = new Puzzle(world, puzzleComponent);

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
