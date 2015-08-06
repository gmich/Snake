using Microsoft.Xna.Framework;
using SnakeClone.Actors;
using SnakeClone.Providers;
using SnakeClone.Rendering;
using System;
using System.Collections.Generic;
using SnakeClone.Utilities;

namespace SnakeClone.Map
{
    internal class RandomFoodFactory : IElementSpawner
    { 
        private readonly Random rand = new Random();
        private readonly double aliveTime;
        private double foodCreationTimeInterval;
        private double passedTime;

        public RandomFoodFactory(double aliveTime)
        {
            this.aliveTime = aliveTime;
            ResetTimer();
        }

        private void ResetTimer()
        {
            foodCreationTimeInterval = rand.Next(2, 6);
        }

        public IGameElement Create(LevelContext context, IList<IGameElement> elements, double timeDelta)        
        {
            passedTime += timeDelta;
            Food food = null;
            if (passedTime >= foodCreationTimeInterval)
            {
                passedTime = 0.0d;
                ResetTimer();
                Vector2 newLocation;
                do
                {
                    newLocation = new Vector2(rand.Next(0, context.Settings.HorizontalTileCount - 1),
                                              rand.Next(0, context.Settings.VerticalTileCount - 1));
                }
                while (context.IsCellEmpty(newLocation));
                
                food = new Food(
                    aliveTime,
                    new Transform(
                            () => new Color(230, 126, 34),
                            () => AssetReference.WhitePixel,
                            () => Vector2.One,
                            () => newLocation,
                            () => 0.0f,
                            () => 0.0f));
                food.SetDisposable(Disposable.Create(elements, food));
            }
            return food;
        }

        public Food Create(double timeDelta)
        {
            throw new NotImplementedException();
        }
    }
}
