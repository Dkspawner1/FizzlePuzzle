using FizzlePuzzle.Scenes;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;
using System.Linq;
using static FizzlePuzzle.Core.Data;

namespace FizzlePuzzle.Managers;

public class SceneManager
{
    private readonly Dictionary<SCENES, SceneBase> scenes;
    private SceneBase currentScene;

    public SceneManager(SpriteBatch spriteBatch)
    {
        scenes = new Dictionary<SCENES, SceneBase>()
        {
            {SCENES.MENU, new MenuScene(spriteBatch)},
            {SCENES.GAME,new GameScene(spriteBatch)},
        };
        currentScene = scenes[SCENES.GAME];
    }
    public void Initialize()
    {
        foreach (var scene in scenes.Values.Where(scene => scene is not null))
            scene.Initialize();

    }
    public void LoadContent(ContentManager Content)
    {
        foreach (var scene in scenes.Values)
            scene.LoadContent(Content);

    }
    public void Update(GameTime gameTime)
    {
        currentScene?.Update(gameTime);
    }
    public void Draw(GameTime gameTime)
    {
        currentScene?.Draw(gameTime);
    }
}
