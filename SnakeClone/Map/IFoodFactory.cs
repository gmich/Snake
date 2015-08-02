using SnakeClone.Actors;

namespace SnakeClone.Map
{
    internal interface IFoodFactory
    {
        bool CanCreate(float timeDelta);

        Food Create();
    }
}