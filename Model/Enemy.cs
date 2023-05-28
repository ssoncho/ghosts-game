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
    public class Enemy : IObject, IGhost, ISolid
    {
        public Enemy(Vector2 initialPosition)
        {
            Position = initialPosition;
        }
        public Image ImageId => Image.Enemy;

        public Vector2 Position { get; private set; }

        public Vector2 Velocity { get; set; }

        public RectangleCollider Collider { get; set; }

        public void Attack(IWeapon weapon)
        {
            throw new NotImplementedException();
        }

        public void Move(Vector2 newPosition)
        {
            Position = newPosition;
            MoveCollider();
        }

        public void MoveCollider()
        {
            Collider = new RectangleCollider((int)Position.X, (int)Position.Y, 64, 128);
        }

        public void Update()
        {
            Move(Position + Velocity);
            Velocity = Vector2.Zero;
        }
    }
}
