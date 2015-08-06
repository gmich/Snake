using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SnakeClone.Rendering;
using SnakeClone.Map;
using SnakeClone.Actors;
using System.Diagnostics;

namespace SnakeClone.Providers
{
    internal class HardCodedAssetProvider : IAssetProvider
    {
        public LevelRenderInfo RenderInfo
        { get; } = new LevelRenderInfo(16, 16, 1.0f);

        public IEnumerable<AssetReference> LoadAssets(AssetContainer<Func<Texture2D>> textureContainer,
                                                      AssetContainer<SpriteFont> fontContainer)
        {
            var assetTileReference = new AssetReference(typeof(ITile), Color.White, "blank");
            var snakeHeadReference = new AssetReference(typeof(SnakePiece), Color.White, "snakeHead");
            var snakeBodyReference = new AssetReference(typeof(SnakePiece), Color.Blue, "snakeBody");

            try
            {
                textureContainer.Add(assetTileReference.Reference,
                              content => new StaticTexture(content.Load<Texture2D>(@"Map/tile")).GetTexture);

                textureContainer.Add(snakeHeadReference.Reference,
                              content => new StaticTexture(content.Load<Texture2D>(@"Mobs/snakeHead")).GetTexture);

                textureContainer.Add(snakeBodyReference.Reference,
                              content => new StaticTexture(content.Load<Texture2D>(@"Mobs/snakeBody")).GetTexture);

                fontContainer.Add("menuFont", content => content.Load<SpriteFont>(@"Fonts/segoe_12"));

            }
            catch (Exception ex)
            {
                Debug.Write("Error while loading content " + ex.Message);
                throw;
            }

            return new List<AssetReference>
            {
                assetTileReference,
                snakeHeadReference,
                snakeBodyReference
            };
        }


    }
}
