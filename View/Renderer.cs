using GhostsGame.Model;
using GhostsGame.Model.Enums;
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
        private Dictionary<Image, Texture2D> textures = new();
        private List<ObjectUI> viewObjects = new();
        public Renderer(ContentManager content, SpriteBatch spriteBatch, 
            Level level, Dictionary<Image, Texture2D> textures)
        {
            this.content = content;
            this.spriteBatch = spriteBatch;
            Level = level;
            textures[Image.Player] = content.Load<Texture2D>("white-ghost");
        }

        public void Update()
        {
            foreach (var obj in Level.Objects)
            {
                
            }
        }

        public void AddObjectsToDraw()
        {
            foreach (var obj in Level.Objects)
            {
                var texture = textures[Image.Player];
                if (obj.ImageId == Image.Player)
                {
                    var rectangle = new Rectangle((int)obj.Position.X, (int)obj.Position.Y, texture.Height, texture.Width);
                    viewObjects.Add(new PlayerUI(rectangle, texture));
                }
            }
        }
    }
}
