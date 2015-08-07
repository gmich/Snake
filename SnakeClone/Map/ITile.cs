namespace SnakeClone.Map
{
    internal interface ITile
    {
        bool Collide();

        void Intersect(LevelContext context);

        void Render(Rendering.RenderContext renderContext);
    }
}
