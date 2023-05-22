﻿using GhostsGame.Model.Enums;
using GhostsGame.Model.Interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhostsGame.Model
{
    public class Player : GameObject, IGhost
    {
        public Player(Vector2 initialPosition) : base(initialPosition)
        {
        }

        public Player(Vector2 initialPosition, Vector2 initialVelocity) : base(initialPosition, initialVelocity)
        {
        }

        public override Image ImageId => Image.Player;

        public override void Update()
        {
            base.Update();
            Velocity = Vector2.Zero;
        }

        public void Attack(IWeapon weapon)
        {
            throw new NotImplementedException();
        }
    }
}
