using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnakeClone.Rendering
{
    internal class RenderContext
    {
        private readonly LevelRenderInfo levelRenderInfo;
        private readonly SpriteBatch batch;
        private readonly AssetContainer<Func<Texture2D>> textureContainer;

        public RenderContext(LevelRenderInfo levelRenderInfo, SpriteBatch batch, AssetContainer<Func<Texture2D>> textureContainer)
        {
            this.levelRenderInfo = levelRenderInfo;
            this.batch = batch;
            this.textureContainer = textureContainer;
        }

        public LevelRenderInfo LevelRenderInfo { get { return levelRenderInfo; } }
        
        public SpriteBatch Batch {  get { return batch; } }

        public AssetContainer<Func<Texture2D>>  TextureContainer {  get { return textureContainer; } }
    }
}
