using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SnakeClone.Rendering
{
    internal class PlainRenderer : IRenderer
    {
        private readonly GraphicsDevice gfxDevice;
        private RenderTarget2D target;
        private Vector2 currentSize = Vector2.Zero;

        public PlainRenderer(GraphicsDevice gfxDevice)
        {
            this.gfxDevice = gfxDevice;
          
     
        }

        public RenderTarget2D Target
        {
            get { return target; }
        }

        public void Flush()
        {
            gfxDevice.SetRenderTarget(null);
        }

        public void Initialize(Vector2 size)
        {
            if (size != currentSize)
            {
                var pp = new PresentationParameters();
                target = new RenderTarget2D(gfxDevice,
                                         (int)size.X,
                                         (int)size.Y,
                                         false,
                                         SurfaceFormat.Color,
                                         pp.DepthStencilFormat,
                                         pp.MultiSampleCount,
                                         RenderTargetUsage.DiscardContents);
            }
        }

        public void Setup()
        {
            gfxDevice.SetRenderTarget(target);
        }
    }
}
