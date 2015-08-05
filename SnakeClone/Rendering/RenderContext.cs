using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

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

        public void RenderInGrid(Transform transform)
        {
            Batch.Draw(TextureContainer[transform.TextureReference](),
                        new Rectangle((int)transform.Location.X * LevelRenderInfo.TileWidth,
                                      (int)transform.Location.Y * LevelRenderInfo.TileHeight,
                                      LevelRenderInfo.TileWidth,
                                      LevelRenderInfo.TileHeight),
                        null,
                        transform.Color,
                        transform.Rotation,
                        Vector2.Zero,
                        SpriteEffects.None,
                        0.0f);
        }
    }
}
