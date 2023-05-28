using GhostsGame.Model;
using GhostsGame.Model.Enums;
using GhostsGame.Model.Interfaces;
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
        private int tileSize;

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
            tileSize = level.TileSize;
            textures[Image.Player] = content.Load<Texture2D>("pixil2");
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
                var newPosition = Level.IdsObjects[objId].Position;
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
                AddObjectToDraw(pair.Value, pair.Key, textures[pair.Value.ImageId]);
        }

        private void AddObjectToDraw(IObject obj, int objId, Texture2D texture)
        {
            var rectangle = new Rectangle(
                        (int)obj.Position.X,
                        (int)obj.Position.Y,
                        texture.Width,
                        texture.Height);
            if (obj is Player)
                idsViewObjects.Add(objId, new PlayerUI(rectangle, texture));
            if (obj is Tile)
                idsViewObjects.Add(objId, new TileUI(rectangle, texture));
        }
    }
}
