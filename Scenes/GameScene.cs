using FizzlePuzzle.ECS.Components;
using FizzlePuzzle.ECS.Entities;
using FizzlePuzzle.ECS.Systems;

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
        var puzzleData = new PuzzleData(ContentLoaderSingleton.Instance.Load<Texture2D>("Textures/landscape-0"), 10, 10, 5, 0.8f);
        PuzzleFactory.CreatePuzzle(world, puzzleData);
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
