using GhostsGame.Model;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhostsGame.Controller
{
    public class ScreenController
    {
        const int TilesCountX = 16;
        const int TilesCountY = 12;
        public Level LoadLevelFromText(string levelDescription)
        {
            Level level = new Level();
            for (int i = 0; i < levelDescription.Length; i++)
            {
                var x = i % TilesCountX;
                var y = i / TilesCountX;
                if (levelDescription[i] == '#')
                    level.AddObject(new Tile(new Vector2(x, y)));
                else if (levelDescription[i] == 'P')
                    level.AddObject(new Player(new Vector2(x, y)));
            }
            return level;
        }
    }
}
