using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhostsGame.View.UI
{
    public abstract class ObjectUI
    {
        public ObjectUI(Vector2 position, Texture2D image)
        {
            Position = position;
            Image = image;
        }

        public Vector2 Position { get; private set; }
        public Texture2D Image { get; private set; }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Image, Position, Color.White);
        }
    }
}
