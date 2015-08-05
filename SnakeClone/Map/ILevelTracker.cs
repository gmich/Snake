using SnakeClone.Providers;

namespace SnakeClone.Map
{
    internal interface ILevelTracker
    {
        ILevelProvider Current { get; }
        ILevelProvider Next { get; }
    }
}
