using Microsoft.Xna.Framework;

namespace SnakeClone
{
    internal static class PointExtensions
    {
        public static Vector2 AsVector2(this Point point)
        {
            return new Vector2(point.X, point.Y);
        }
    }
}


