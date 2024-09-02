
using FizzlePuzzle.ECS.Components;
using MonoGame.Extended.ECS;

namespace FizzlePuzzle.ECS.Entities;

public class Puzzle
{
    protected Entity entity;
    public Puzzle(World world,PuzzleComponent puzzleComponent)
    {
        entity = world.CreateEntity();
        entity.Attach(puzzleComponent);
    }
}
