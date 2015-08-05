using SnakeClone.Actors;

namespace SnakeClone.Map
{
    internal interface IFoodFactory
    {
        Food Create(double timeDelta);
    }
}