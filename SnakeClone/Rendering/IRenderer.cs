using Microsoft.Xna.Framework.Graphics;

namespace SnakeClone.Rendering
{
    internal interface IRenderer
    {
        RenderTarget2D Target { get; }

        void Cleanup();

        void Render(SpriteBatch batch, Transform transform);

        void Flush();
    }
}
