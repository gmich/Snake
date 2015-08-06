namespace SnakeClone.Map
{
    internal interface ITile
    {
        bool Intersect(LevelContext context);

        void Render(Rendering.RenderContext renderContext);
    }
}
