using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SnakeClone.Actors
{
    internal interface IGameElement
    {
        void HandleState();
        void Update(float deltaTime);
        void Render(SpriteBatch batch);
    }
}
