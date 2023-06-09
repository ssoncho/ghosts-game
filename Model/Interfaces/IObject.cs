﻿using GhostsGame.Model.Enums;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhostsGame.Model.Interfaces
{
    public interface IObject
    {
        public Image ImageId { get; }
        public Vector2 Position { get; }
        public Vector2 Velocity { get; set; }

        public void Update();

        public void Move(Vector2 newPosition);
    }
}
