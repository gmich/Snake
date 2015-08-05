﻿using SnakeClone.Rendering;

namespace SnakeClone.Actors
{
    internal class Food : IGameElement
    {
        private readonly Transform transform;

        public Food(Transform transform)
        {
            this.transform = transform;
        }

        public void Update(double deltaTime)
        {
            return;
        }

        public void Render(RenderContext renderContext)
        {
            renderContext.RenderInGrid(transform);
        }

    }
}
