using SnakeClone.Providers;

namespace SnakeClone.Map
{
    internal class LevelTracker : ILevelTracker
    {
        public ILevelProvider Current
        {
            get { return new HardCodedLevelProvider(); }
        }

        public ILevelProvider Next
        {
            get { return new HardCodedLevelProvider(); }
        }
    }
}
