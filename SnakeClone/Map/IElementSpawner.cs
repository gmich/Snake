using SnakeClone.Actors;
using System.Collections.Generic;

namespace SnakeClone.Map
{
    internal interface IElementSpawner
    {
        IGameElement Create(LevelContext context, IList<IGameElement> elements, double timeDelta);
    }
}