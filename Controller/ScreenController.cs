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
        public ScreenController(int tilesCountX, int tilesCountY, int tileSize)
        {
            this.tilesCountX = tilesCountX;
            this.tilesCountY = tilesCountY;
            this.tileSize = tileSize;
        }
        private readonly int tilesCountX;
        private readonly int tilesCountY;
        private readonly int tileSize;
        public Level LoadLevelFromText(string levelDescription)
        {
            Level level = new Level(tileSize);
            for (int i = 0; i < levelDescription.Length; i++)
            {
                var x = i % tilesCountX;
                var y = i / tilesCountX;
                if (levelDescription[i] == '#')
                    level.AddObject(new Tile(tileSize * new Vector2(x, y)));
                else if (levelDescription[i] == 'P')
                    level.AddObject(new Player(tileSize * new Vector2(x, y)));
            }
            return level;
        }
    }
}
