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
        public ObjectUI(Rectangle rectangle, Texture2D image)
        {
            Rectangle = rectangle;
            Image = image;
        }

        public Rectangle Rectangle { get; private set; }
        public Texture2D Image { get; private set; }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Image, Rectangle, Color.White);
        }
    }
}
