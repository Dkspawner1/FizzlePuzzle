using FizzlePuzzle.Managers;

namespace FizzlePuzzle.Core;
public class Game1 : Game
{
    private SceneManager sceneManager;

    public Game1()
    {
        _ = new GraphicsDeviceManager(this)
        {
            PreferredBackBufferWidth = Data.Window.Width,
            PreferredBackBufferHeight = Data.Window.Height,
        };
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        SpriteBatchSingleton.Initialize(GraphicsDevice);


        sceneManager = new SceneManager(SpriteBatchSingleton.Instance.SpriteBatch);
        sceneManager.Initialize();

        base.Initialize();
    }

    protected override void LoadContent()
    {


        sceneManager.LoadContent(Content);

    }

    protected override void Update(GameTime gameTime)
    {

        sceneManager.Update(gameTime);

        if (Data.Window.Exit)
            Exit();

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.DeepPink);
        sceneManager.Draw(gameTime);

        base.Draw(gameTime);
    }
}
