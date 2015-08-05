using SnakeClone.Actors;
using System;

namespace SnakeClone.Map
{
    class RandomFoodFactory : IFoodFactory
    {
        private readonly Random rand = new Random();
        private double foodCreationTimeInterval;
        private double passedTime;

        public RandomFoodFactory()
        {
            ResetTimer();
        }

        private void ResetTimer()
        {
            foodCreationTimeInterval = rand.Next(2, 10) / 100;
        }

        public Food Create(double timeDelta)        
        {
            passedTime += timeDelta;
            if (passedTime >= foodCreationTimeInterval)
            {
                passedTime = 0.0d;
                ResetTimer();
                return new Food(null);
            }
            return null;
        }
    }
}
