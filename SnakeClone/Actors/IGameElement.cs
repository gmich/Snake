using SnakeClone.Rendering;

namespace SnakeClone.Actors
{
    internal interface IGameElement
    {
        void Update(float deltaTime);
        void Render(RenderContext renderContext);
    }
}
