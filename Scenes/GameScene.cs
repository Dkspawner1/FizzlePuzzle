
using Microsoft.Xna.Framework.Content;
using MonoGame.Extended.ECS;

namespace FizzlePuzzle.Scenes;

public class GameScene : SceneBase
{
    public GameScene(SpriteBatch spriteBatch) : base(spriteBatch)
    {
        world = new WorldBuilder().Build();

    }
    public override void Initialize()
    {
    }

    public override void LoadContent(ContentManager Content)
    {

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
