
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;

namespace FizzlePuzzle.Core;

public class ContentLoaderSingleton
{
    private static ContentLoaderSingleton instance;
    internal ContentManager content;
    private Dictionary<string, object> loadedContent;


    private ContentLoaderSingleton(ContentManager content)
    {
        this.content = content;
        loadedContent = new Dictionary<string, object>();
    }

    public static ContentLoaderSingleton Instance
    {
        get
        {
            if (instance is null)
            {
                throw new InvalidOperationException("ContentLoaderSingleton must be initialized with a ContentManager before use.");
            }
            return instance;
        }
    }
    public static void Initialize(ContentManager content) => instance = new ContentLoaderSingleton(content);

    public T Load<T>(string assetName)
    {
        if (loadedContent.TryGetValue(assetName, out object asset))
        {
            return (T)asset;
        }

        T loadedAsset = content.Load<T>(assetName);
        loadedContent[assetName] = loadedAsset;
        return loadedAsset;
    }
    public void Unload(string assetName)
    {
        if (loadedContent.Remove(assetName, out object asset))
        {
            if (asset is IDisposable disposable)
                disposable.Dispose();
        }
    }
    public void UnloadAll()
    {
        foreach (var asset in loadedContent.Values)
        {
            if (asset is IDisposable disposable)
            {
                disposable.Dispose();
            }
        }
        loadedContent.Clear();
        content.Unload();
    }
}
