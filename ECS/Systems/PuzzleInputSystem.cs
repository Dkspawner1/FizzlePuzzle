
using FizzlePuzzle.ECS.Components;
using MonoGame.Extended.ECS;
using MonoGame.Extended.ECS.Systems;

namespace FizzlePuzzle.ECS.Systems;

public class PuzzleInputSystem : EntityUpdateSystem
{

    private ComponentMapper<PuzzlePieceComponent> pieceMapper;
    private MouseState previousMouseState;

    public PuzzleInputSystem() : base(Aspect.All(typeof(PuzzlePieceComponent)))
    {

    }

    public override void Initialize(IComponentMapperService mapperService)
    {
        pieceMapper = mapperService.GetMapper<PuzzlePieceComponent>();
    }

    public override void Update(GameTime gameTime)
    {
        MouseState currentMouseState = Mouse.GetState();

        if (currentMouseState.LeftButton == ButtonState.Pressed && previousMouseState.LeftButton == ButtonState.Released)
        {
            // Mouse Click
            Vector2 mousePosition = currentMouseState.Position.ToVector2();
            SelectPiece(mousePosition);
        }
        else if (currentMouseState.LeftButton == ButtonState.Released && previousMouseState.LeftButton == ButtonState.Pressed)
        {
            DropPiece();
        }
        else if (currentMouseState.LeftButton == ButtonState.Pressed)
        {
            Vector2 mousePosition = currentMouseState.Position.ToVector2();
            DragPiece(mousePosition);
        }
        previousMouseState = currentMouseState;
    }
    private void SelectPiece(Vector2 mousePosition)
    {
        foreach (var entity in ActiveEntities)
        {
            var piece = pieceMapper.Get(entity);
            if (piece.Bounds.Contains(mousePosition))
            {
                piece.IsSelected = true;
                break;
            }
        }
    }
    private void DragPiece(Vector2 mousePosition)
    {
        foreach (var entity in ActiveEntities)
        {
            var piece = pieceMapper.Get(entity);
            if (piece.IsSelected)
            {
                piece.CurrentPosition = mousePosition - new Vector2(piece.Bounds.Width / 2, piece.Bounds.Height / 2);
                piece.Bounds = new Rectangle((int)piece.CurrentPosition.X, (int)piece.CurrentPosition.Y, piece.Bounds.Width, piece.Bounds.Height);
            }
        }
    }
    private void DropPiece()
    {
        foreach (var entity in ActiveEntities)
        {
            var piece = pieceMapper.Get(entity);
            if (piece.IsSelected)
            {
                piece.IsSelected = false;
            }
        }
    }
}
