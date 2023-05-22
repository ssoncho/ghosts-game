using GhostsGame.Model.Enums;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhostsGame.Model
{
    public abstract class GameObject
    {
        public GameObject(Vector2 initialPosition)
        {
            Position = initialPosition;
        }

        public GameObject(Vector2 initialPosition, Vector2 initialVelocity) : this(initialPosition)
        {
            Velocity = initialVelocity;
        }

        public abstract Image ImageId { get; }
        public Vector2 Position { get; set; } = Vector2.Zero;
        public Vector2 Velocity { get; set; } = Vector2.Zero;

        public virtual void Update()
        {
            Position += Velocity;
        }
    }
}
