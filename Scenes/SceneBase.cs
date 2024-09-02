
using Microsoft.Xna.Framework.Content;
using MonoGame.Extended.ECS;
using MonoGame.Extended.ECS.Systems;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace FizzlePuzzle.Scenes;

public abstract class SceneBase
{
    protected World world;
    protected SceneBase(SpriteBatch spriteBatch,[Optional]IEnumerable<ISystem> systems)
    {
        //var worldBuilder = new WorldBuilder();
        //foreach (var system in systems)
        //    worldBuilder.AddSystem(system);
        //world = worldBuilder.Build();
    }
    public abstract void Initialize();
    public abstract void LoadContent(ContentManager Content);
    public virtual void Update(GameTime gameTime) => world.Update(gameTime);
    public virtual void Draw(GameTime gameTime) => world.Draw(gameTime);
}
