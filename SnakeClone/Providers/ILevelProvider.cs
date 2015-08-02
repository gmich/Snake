using SnakeClone.Map;

namespace SnakeClone.Providers
{
    internal interface ILevelProvider
    {
        ITile[,] Grid { get; }

        LevelSettings LevelSettings { get; }

    }
}
