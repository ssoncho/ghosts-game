using GhostsGame.Model.Enums;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhostsGame.Model
{
    public class Level
    {
        public Vector2 PlayerPosition { get; private set; }

        public Level(Vector2 initialPlayerPosition)
        {
            PlayerPosition = initialPlayerPosition;
        }

        public void SetPlayerPosition(Direction direction)
        {
            if (direction == Direction.Down)
                PlayerPosition += Vector2.UnitY;
            if (direction == Direction.Up)
                PlayerPosition -= Vector2.UnitY;
            if (direction == Direction.Right)
                PlayerPosition += Vector2.UnitX;
            else
                PlayerPosition -= Vector2.UnitX;
        }
    }
}
