using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SnakeClone.Actors;
using SnakeClone.Actors.States;
using System;
using System.Collections.Generic;

namespace SnakeClone.Map
{
    internal class LevelContext
    {
        private readonly Queue<ISnakeState> states = new Queue<ISnakeState>();
        private readonly Spawner<SnakePiece> tailSpawner;
        private readonly SnakePiece snakeHead;
        private readonly LevelSettings settings;
        private readonly Action restart;
        private readonly Action nextLevel;
        private readonly Predicate<Vector2> cellIsEmpty;

        public LevelContext(SnakePiece snakeHead,
                            LevelSettings settings,
                            Spawner<SnakePiece> tailSpawner,
                            Direction initialDirection,
                            Action restart,
                            Action nextLevel,
                            Predicate<Vector2> cellIsEmpty,
                            int lives)
        {
            this.cellIsEmpty = cellIsEmpty;
            this.settings = settings;
            this.nextLevel = nextLevel;
            this.tailSpawner = tailSpawner;
            this.snakeHead = snakeHead;
            this.restart = restart;
            Direction = initialDirection;
            Lives = lives;
        }

        public int Lives
        {
            get; set;
        }

        public int Score
        {
            get; set;
        }

        public LevelSettings Settings { get { return settings; } }

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

        public void NextLevel()
        {
            restart();
        }

        public bool IsCellEmpty(Vector2 cell)
        {
            return cellIsEmpty(cell);
        }

        public bool IsCellDamageable(Vector2 cell)
        {
            //TODO: implement this
            //return snakeHead.Intersects(cell);
            return false;
        }

        public void AddState(ISnakeState state)
        {
            states.Enqueue(state);
        }

        public ISnakeState GetState()
        {
            return (states.Count > 0) ?
                states.Dequeue() : null;
        }
    }
}
