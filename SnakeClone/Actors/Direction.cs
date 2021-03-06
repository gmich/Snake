﻿using Microsoft.Xna.Framework;
using System;

namespace SnakeClone.Actors
{
    internal class Direction
    {
        private readonly Func<Point, Point> getNext;
        private Direction(Func<Point, Point> next)
        {
            getNext = next;
        }
        public Point Move(Point current)
        {
            return getNext(current);
        }

        private static Lazy<Direction> up = new Lazy<Direction>(() =>
            new Direction(current => new Point(current.X, current.Y-1)));
        public static Direction Up
        {
            get { return up.Value; }
        }

        private static Lazy<Direction> down = new Lazy<Direction>(() =>
            new Direction(current => new Point(current.X, current.Y+1)));
        public static Direction Down
        {
            get { return down.Value; }
        }

        private static Lazy<Direction> left = new Lazy<Direction>(() =>
            new Direction(current => new Point(current.X-1, current.Y)));
        public static Direction Left
        {
            get { return left.Value; }
        }

        private static Lazy<Direction> right = new Lazy<Direction>(() =>
           new Direction(current => new Point(current.X+1, current.Y)));
        public static Direction Right
        {
            get { return right.Value; }
        }

    }
}
