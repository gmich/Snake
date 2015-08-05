using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SnakeClone.Rendering
{
    class NotransformationRenderer 
    {
        private readonly GraphicsDevice gfxDevice;
        private readonly SpriteBatch batch;
        private readonly RenderTarget2D target;

        public NotransformationRenderer(GraphicsDevice gfxDevice, SpriteBatch batch, int pixelWidth, int pixelHeight)
        {
            this.batch = batch;
            this.gfxDevice = gfxDevice;
            PresentationParameters pp = gfxDevice.PresentationParameters;
            target = new RenderTarget2D(gfxDevice,
                                        pp.BackBufferWidth,
                                        pp.BackBufferHeight,
                                        false,
                                        SurfaceFormat.Color,
                                        pp.DepthStencilFormat,
                                        pp.MultiSampleCount,
                                        RenderTargetUsage.DiscardContents);
        }

        public RenderTarget2D Target
        {
            get { return target; }
        }

        public void Cleanup()
        {
            gfxDevice.SetRenderTarget(target);
            gfxDevice.Clear(Color.Transparent);
            batch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend);
        }

        public void Flush()
        {
            throw new NotImplementedException();
        }

        public void Render(SpriteBatch batch, Transform transform)
        {
            //batch.Draw(transform.Texture,transform.Location,transform.Color)
        }
    }
}
