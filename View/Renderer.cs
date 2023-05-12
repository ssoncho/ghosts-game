using GhostsGame.Model;
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
        public readonly Level Level;
        private ContentManager content;
        private SpriteBatch spriteBatch;
        public Renderer(ContentManager content, SpriteBatch spriteBatch, Level level)
        {
            this.content = content;
            this.spriteBatch = spriteBatch;
            Level = level;
            Player = CreatePlayer();
        }

        public void Update()
        {
            
        }

        public PlayerUI CreatePlayer()
        {
            var playerImage = content.Load<Texture2D>("white-ghost");
            var playerRectangle = new Rectangle(0, 0, 125, 125);
            return new PlayerUI(playerRectangle, playerImage);
        }
    }
}
