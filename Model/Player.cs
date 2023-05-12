using GhostsGame.Model.Enums;
using GhostsGame.Model.Interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhostsGame.Model
{
    public class Player : IGhost
    {
        public Player(Vector2 initialPosition)
        {
            Position = initialPosition;
        }
        public Vector2 Position { get; private set; }

        public Image ImageId => Image.Player;

        public void Attack(IWeapon weapon)
        {
            throw new NotImplementedException();
        }

        public void Move(Direction direction)
        {
            if (direction == Direction.Down)
                Position += Vector2.UnitY;
            else if (direction == Direction.Up)
                Position -= Vector2.UnitY;
            else if (direction == Direction.Right)
                Position += Vector2.UnitX;
            else
                Position -= Vector2.UnitX;
        }
    }
}
