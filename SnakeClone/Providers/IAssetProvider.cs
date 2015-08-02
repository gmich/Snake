using Microsoft.Xna.Framework.Graphics;
using SnakeClone.Rendering;
using System;
using System.Collections.Generic;

namespace SnakeClone.Providers
{
    interface IAssetProvider
    {
        IEnumerable<AssetReference> LoadAssets(AssetContainer<Func<Texture2D>> container);

        LevelRenderInfo RenderInfo { get; }
    }
}
