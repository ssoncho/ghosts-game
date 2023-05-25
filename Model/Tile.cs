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
    public class Tile : GameObject, ISolid
    {
        public Tile(Vector2 initialPosition) : base(initialPosition)
        {
        }

        public override void Update()
        {
            base.Update();
            MoveCollider();
            Velocity = Vector2.Zero;
        }

        public override Image ImageId => Image.StaticTile;

        public RectangleCollider Collider { get; private set; }

        public void MoveCollider()
        {
            Collider = new RectangleCollider((int)Position.X, (int)Position.Y, 64, 64);
        }
    }
}
