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
        { get; } = new LevelRenderInfo(64, 64, 1.0f);

        public IEnumerable<AssetReference> LoadAssets(AssetContainer<Func<Texture2D>> container)
        {
            var assetTileReference = new AssetReference(typeof(BlankTile), Color.White, "blankTile");
            var snakeHeadReference = new AssetReference(typeof(SnakePiece), Color.White, "snakeHead");
            var snakeBodyReference = new AssetReference(typeof(SnakePiece), Color.Blue, "snakeBody");

            try
            {
                container.Add(assetTileReference.Reference,
                              content => new StaticTexture(content.Load<Texture2D>(@"Content/Map/tile")).GetTexture);

                container.Add(snakeHeadReference.Reference,
                              content => new StaticTexture(content.Load<Texture2D>(@"Content/Mobs/snakeHead")).GetTexture);

                container.Add(snakeHeadReference.Reference,
                              content => new StaticTexture(content.Load<Texture2D>(@"Content/Mobs/snakeBody")).GetTexture);
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
