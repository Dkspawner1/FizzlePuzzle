using FizzlePuzzle.Scenes;
using System;
using System.Collections.Generic;
using System.Linq;
using static FizzlePuzzle.Core.Data;

namespace FizzlePuzzle.Managers;

public class SceneManager
{
    private readonly Dictionary<SCENES, SceneBase> scenes;
    private SceneBase currentScene, nextScene;

    public SceneManager()
    {
        scenes = new();
        AddScene(SCENES.MENU, new MenuScene());
        AddScene(SCENES.GAME, new GameScene());
        LoadScene(SCENES.GAME);
        currentScene = scenes[SCENES.GAME];
    }

    public void Initialize()
    {
        foreach (var scene in scenes.Values.Where(scene => scene is not null))
            scene.Initialize();

    }

    public void AddScene(SCENES sceneName, SceneBase scene) => scenes[sceneName] = scene;

    public void LoadScene(SCENES sceneName)
    {
        if (scenes.TryGetValue(sceneName, out SceneBase scene))
        {
            nextScene = scene;
        }
        else
            throw new ArgumentException($"Scene {sceneName} not found.");

    }

    public void Update(GameTime gameTime)
    {
        if (nextScene != null)
        {
            currentScene?.UnloadContent();
            nextScene.LoadContent();
            currentScene = nextScene;
            nextScene = null;
        }
        currentScene?.Update(gameTime);
    }
    public void Draw(GameTime gameTime)
    {
        currentScene?.Draw(gameTime);
    }
}
