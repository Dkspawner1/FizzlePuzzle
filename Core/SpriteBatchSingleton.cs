using System;

namespace FizzlePuzzle.Core;

public class SpriteBatchSingleton : ISpriteBatchSingleton
{


    private static SpriteBatchSingleton instance;
    private static readonly object @lock = new object();
    public SpriteBatch SpriteBatch { get; }
    private SpriteBatchSingleton(GraphicsDevice graphics) => SpriteBatch = new SpriteBatch(graphics);


    public static SpriteBatchSingleton Instance
    {
        get
        {
            if (instance is null)
            {
                throw new InvalidOperationException("SpriteBatchSingleton has not been initialized. Call Initialize() first.");
            }
            return instance;
        }
    }
    public static void Initialize(GraphicsDevice graphics)
    {
        if (instance is not null)
        {
            throw new InvalidOperationException("SpriteBatchSingleton has already been initialized.");
        }

        lock (@lock)
        {
            if (instance is null)
            {
                instance = new SpriteBatchSingleton(graphics);
            }
        }

    }

}
