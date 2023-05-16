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
        private Dictionary<int, ObjectUI> idsViewObjects = new();
        public Renderer(ContentManager content, SpriteBatch spriteBatch, 
            Level level)
        {
            this.content = content;
            this.spriteBatch = spriteBatch;
            Level = level;
            textures[Image.Player] = content.Load<Texture2D>("white-ghost-right-weapon");
            AddObjectsToDraw();
        }

        public void Update()
        {
            foreach (var pair in idsViewObjects)
            {
                var objId = pair.Key;
                var viewObj = pair.Value;
                var newPosition = Level.IdsObjects[objId].Position;
                viewObj.Rectangle = new Rectangle(
                    (int)newPosition.X*32, (int)newPosition.Y*32, //unit test, doesn't work properly
                    viewObj.Rectangle.Width, 
                    viewObj.Rectangle.Height);
                viewObj.Draw(spriteBatch);
            }
        }

        private void AddObjectsToDraw()
        {
            foreach (var pair in Level.IdsObjects)
            {
                var obj = pair.Value;
                var texture = textures[Image.Player];
                if (obj.ImageId == Image.Player)
                {
                    var rectangle = new Rectangle((int)obj.Position.X, (int)obj.Position.Y, texture.Height, texture.Width);
                    idsViewObjects.Add(pair.Key, new PlayerUI(rectangle, texture));
                }
            }
        }
    }
}
