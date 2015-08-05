using SnakeClone.Rendering;

namespace SnakeClone.Actors
{
    internal interface IGameElement
    {
        void Update(double deltaTime);
        void Render(RenderContext renderContext);
    }
}
