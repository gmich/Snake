namespace SnakeClone.Map
{
    internal interface ITile
    {
        void Intersect(LevelContext context);

        void Render(Rendering.RenderContext renderContext);
    }
}
