using SnakeClone.Map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnakeClone.Actors.States
{
    class AddTailState : ISnakeState
    {
        public void Handle(LevelContext context)
        {
            context.SnakeHead.Bind(context.TailSpawner.Spawn());
        }
    }
}
