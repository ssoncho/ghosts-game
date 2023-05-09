using GhostsGame.Model.Enums;
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
        public Player Player { get; private set; }

        public Level(Vector2 initialPlayerPosition)
        {
            Player = new Player(initialPlayerPosition);
        }
    }
}
