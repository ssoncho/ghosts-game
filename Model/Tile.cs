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
    public class Tile : GameObject
    {
        public Tile(Vector2 initialPosition) : base(initialPosition)
        {
        }
        public override Image ImageId => Image.StaticTile;
    }
}
