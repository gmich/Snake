using SnakeClone.Map;

namespace SnakeClone.Actors.States
{
    internal interface ISnakeState
    {
        void Handle(LevelContext levelContext);
    }
}
