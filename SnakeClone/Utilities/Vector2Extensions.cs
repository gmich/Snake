using Microsoft.Xna.Framework;

namespace SnakeClone
{
    internal static class Vector2Extensions
    {
        public static Point AsPoint(this Vector2 vector)
        {
            return new Point((int)vector.X, (int)vector.Y);
        }
    }
}
