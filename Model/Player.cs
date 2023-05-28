using GhostsGame.Model.Enums;
using GhostsGame.Model.Interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhostsGame.Model
{
    public class Player : IObject, IGhost, ISolid
    {
        public Player(Vector2 position)
        {
            Position = position;
        }

        public Image ImageId => Image.Player;

        public Vector2 Position { get; private set; }

        public Vector2 Velocity { get; set; } = Vector2.Zero;

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
            //Velocity = Vector2.Zero;
        }
    }
}
