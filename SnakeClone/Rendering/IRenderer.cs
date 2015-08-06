using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SnakeClone.Rendering
{
    internal interface IRenderer
    {
        void Initialize(Vector2 size);

        void Setup();

        RenderTarget2D Target { get; }

        void Flush();
    }
}
