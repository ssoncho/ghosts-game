using GhostsGame.Model;
using GhostsGame.Model.Enums;
using GhostsGame.View.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhostsGame.View
{
    public class Renderer
    {
        public const int TileSize = 64;

        public readonly Level Level;
        private ContentManager content;
        private SpriteBatch spriteBatch;
        private Dictionary<Image, Texture2D> textures = new();
        private Dictionary<int, ObjectUI> idsViewObjects = new();

        public Renderer(Level level)
        {
            this.content = EntryPoint.Game.Content;
            this.spriteBatch = new SpriteBatch(EntryPoint.Game.GraphicsDevice);
            Level = level;
            textures[Image.Player] = content.Load<Texture2D>("white-ghost-right-weapon");
            textures[Image.StaticTile] = content.Load<Texture2D>("tile");
            AddObjectsToDraw();
        }

        public void Update()
        {
            spriteBatch.Begin();
            foreach (var pair in idsViewObjects)
            {
                var objId = pair.Key;
                var viewObj = pair.Value;
                var newPosition = Level.IdsObjects[objId].Position * 64;
                viewObj.Rectangle = new Rectangle(
                    (int)newPosition.X, (int)newPosition.Y,
                    viewObj.Rectangle.Width, 
                    viewObj.Rectangle.Height);
                viewObj.Draw(spriteBatch);
            }
            spriteBatch.End();
        }

        private void AddObjectsToDraw()
        {
            foreach (var pair in Level.IdsObjects)
            {
                var obj = pair.Value;
                var texture = textures[obj.ImageId];
                if (obj is Player)
                {
                    var rectangle = new Rectangle(
                        ((int)obj.Position.X) * TileSize, 
                        ((int)obj.Position.Y) * TileSize, 
                        texture.Height, 
                        texture.Width);
                    idsViewObjects.Add(pair.Key, new PlayerUI(rectangle, texture));
                }
                if (obj is Tile)
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
