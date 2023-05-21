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
        public const int TileSize = 64;

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
            textures[Image.StaticTile] = content.Load<Texture2D>("tile");
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
                    (int)newPosition.X * 10, (int)newPosition.Y * 10,
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
                var texture = textures[obj.ImageId];
                if (obj.ImageId == Image.Player)
                {
                    var rectangle = new Rectangle(
                        ((int)obj.Position.X - 1) * TileSize, 
                        ((int)obj.Position.Y - 1) * TileSize, 
                        texture.Height, 
                        texture.Width);
                    idsViewObjects.Add(pair.Key, new PlayerUI(rectangle, texture));
                }
                if (obj.ImageId == Image.StaticTile)
                {
                    var rectangle = new Rectangle(
                        (int)obj.Position.X * TileSize,
                        (int)obj.Position.Y * TileSize,
                        texture.Height,
                        texture.Width);
                    idsViewObjects.Add(pair.Key, new TileUI(rectangle, texture));
                }
            }
        }
    }
}
