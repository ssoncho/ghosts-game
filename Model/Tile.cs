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
    public class Tile : IObject
    {
        public Tile(Vector2 initialPosition)
        {
            Position = initialPosition;
        }
        public Image ImageId => Image.StaticTile;

        public Vector2 Position { get; private set; }

        public void Move(Direction direction)
        {
            throw new NotImplementedException();
        }
    }
}
