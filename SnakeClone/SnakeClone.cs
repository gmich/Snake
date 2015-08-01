using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SnakeClone.Actors;
using SnakeClone.Map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnakeClone
{
    class SnakeClone
    {
        private readonly Level level;
        private readonly List<IGameElement> elements = new List<IGameElement>();
        private readonly Snake snake;

        public SnakeClone(GameType gameType)
        {
            level = new Level(new BlankMapGenerator(gameType.SizeX, gameType.SizeY), 
                              AdjustmentRules.Default(gameType.SizeX, gameType.SizeY));

            //snake = new Snake();
            elements.Add(snake);
        }

        public void HandleState()
        {

        }
        public void Update(float deltaTime)
        {

        }

        public void Render(SpriteBatch batch)
        {

        }

    }
}
