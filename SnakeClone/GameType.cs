using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnakeClone
{
    public class GameType
    {
        private readonly int sizeX;
        private readonly int sizeY;
        private readonly int lives;

        private GameType(int sizeX, int sizeY, int lives)
        {
            this.sizeX = sizeX;
            this.sizeY = sizeY;
            this.lives = lives;
        }

        public int SizeX { get { return sizeX; } }
        public int SizeY { get { return sizeY; } }
        public int Lives { get { return lives; } }


        private static Lazy<GameType> easy = new Lazy<GameType>(() => new GameType(50, 50, 3));
        public static GameType Easy
        {
            get { return easy.Value; }
        }

        private static Lazy<GameType> hard = new Lazy<GameType>(()=>new GameType(100,100,3));
        public static GameType Hard
        {
            get { return hard.Value; }
        }
    }
}
