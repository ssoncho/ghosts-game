﻿using Microsoft.Xna.Framework;
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
        public ObjectUI(Vector2 position)
        {
            Rectangle = new Rectangle((int)position.X, (int)position.Y, 0, 0);
        }

        public ObjectUI(Rectangle rectangle, Texture2D texture)
        {
            Rectangle = rectangle;
            Texture = texture;
        }

        public Rectangle Rectangle { get; set; }
        public Texture2D Texture { get; private set; }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (Texture != null)
                spriteBatch.Draw(Texture, Rectangle, Color.White);
        }
    }
}
