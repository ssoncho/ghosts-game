using GhostsGame.View.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhostsGame.View
{
    public class Renderer
    {
        public PlayerUI Player { get; private set; }
        public Renderer(ContentManager content)
        {
            Player = CreatePlayer(content);
        }

        public PlayerUI CreatePlayer(ContentManager content)
        {
            var playerImage = content.Load<Texture2D>("white-ghost");
            var playerRectangle = new Rectangle(0, 0, 125, 125);
            return new PlayerUI(playerRectangle, playerImage);
        }
    }
}
