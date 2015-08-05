using Microsoft.Xna.Framework;
using System;

namespace SnakeClone.Map
{
    internal class AdjustmentRules
    {
        private readonly Func<int, int> horizontalAdjustmentRule;
        private readonly Func<int, int> verticalAdjustmentRule;
        
        public AdjustmentRules(Func<int, int> horizontalAdjustmentRule, Func<int, int> verticalAdjustmentRule)
        {
            this.horizontalAdjustmentRule = horizontalAdjustmentRule;
            this.verticalAdjustmentRule = verticalAdjustmentRule;
        }

        public Point Apply(Point other)
        {
            return new Point(horizontalAdjustmentRule(other.X), verticalAdjustmentRule(other.Y));
        }

        public static AdjustmentRules Default(int upperHorizontalBound, int upperVerticalBound)
        {
            return new AdjustmentRules(x =>
            {
                if (x < 0)
                {
                    return upperHorizontalBound;
                }
                else if (x > upperHorizontalBound)
                {
                    return 0;
                }
                return x;
            }, y =>
            {
                if (y < 0)
                {
                    return upperVerticalBound;
                }
                else if (y > upperVerticalBound)
                {
                    return 0;
                }
                return y;
            });
        }


    }
}
