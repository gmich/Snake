using Microsoft.Xna.Framework;
using SnakeClone.Map;
using SnakeClone.Rendering;

namespace SnakeClone.Actors
{
    internal interface IGameElement
    {
        bool Intersects(Vector2 location);
        void Update(LevelContext context, double deltaTime);
        void Render(RenderContext renderContext);
    }
}
