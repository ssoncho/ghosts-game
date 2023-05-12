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
    public class Level
    {
        public readonly Dictionary<int, IObject> IdsObjects = new();
        public Player Player { get; set; }
        public Level(Vector2 initialPlayerPosition)
        {
            Player = new Player(initialPlayerPosition);
            IdsObjects.Add(1, Player);
        }
    }
}
