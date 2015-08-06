using SnakeClone.Actors;
using SnakeClone.Map;

namespace SnakeClone.Providers
{
    internal interface ILevelProvider
    {
        ITile[,] Grid { get; }

        LevelSettings LevelSettings { get; }

        IElementSpawner ElementSpawner { get;  }

        SnakePiece Head { get; }

        Spawner<SnakePiece> TailSpawner { get; }

    }
}
