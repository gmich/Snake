using SnakeClone.Actors;
using SnakeClone.Actors.States;
using System;
using System.Collections.Generic;

namespace SnakeClone.Map
{
    internal class LevelContext
    {
        private readonly Spawner<SnakePiece> tailSpawner;
        private readonly SnakePiece snakeHead;
        private readonly Queue<ISnakeState> states;
        private readonly Action restart;

        public LevelContext(SnakePiece snakeHead, Spawner<SnakePiece> tailSpawner,Direction initialDirection,Action restart, int lives)
        {
            this.tailSpawner = tailSpawner;
            this.snakeHead = snakeHead;
            this.restart = restart;
            Direction = initialDirection;
            Lives = lives;
        }
        public int Lives { get; set; }

        public Spawner<SnakePiece> TailSpawner
        {
            get { return tailSpawner; }
        }

        public SnakePiece SnakeHead
        {
            get { return snakeHead; }
        }

        public Direction Direction
        {
            get;
            set;
        }

        public void RestartLevel()
        {
            restart();
        }

        public void AddState(ISnakeState state)
        {
            states.Enqueue(state);
        }

        public ISnakeState GetState()
        {
            return states.Dequeue();
        }
    }
}
