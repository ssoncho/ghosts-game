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
        private readonly ContentManager content;
        private readonly SpriteBatch spriteBatch;
        private readonly GraphicsDevice graphicsDevice;
        private Dictionary<Image, Texture2D> textures = new();
        private Dictionary<int, ObjectUI> idsViewObjects = new();

        private SpriteFont spriteFont;

        private float percentage;

        public Renderer(Level level)
        {
            this.content = EntryPoint.Game.Content;
            this.graphicsDevice = EntryPoint.Game.GraphicsDevice;
            this.spriteBatch = new SpriteBatch(graphicsDevice);

            Level = level;
            tileSize = level.TileSize;
            textures[Image.Player] = content.Load<Texture2D>("white-ghost-right-weapon");
            textures[Image.StaticTile] = content.Load<Texture2D>("tile");
            textures[Image.Fire] = content.Load<Texture2D>("fire");
            AddObjectsToDraw();
            idsViewObjects[0] = new ScoreUI(new Vector2(96, 64));
            spriteFont = content.Load<SpriteFont>("basic-font");
            percentage = 1.0f / Level.MaxScore;
        }

        public void Update()
        {
            var currentColorPercentage = Level.CurrentScore * percentage;
            graphicsDevice.Clear(new Color(currentColorPercentage, currentColorPercentage, currentColorPercentage));

            spriteBatch.Begin();
            foreach (var pair in idsViewObjects)
            {
                var objId = pair.Key;
                var viewObj = pair.Value;
                if (objId == 0)
                {
                    var textColorPercentage = 1.0f - currentColorPercentage;
                    if (textColorPercentage == 0.5f)
                        textColorPercentage = 0.6f;
                    var textColor = new Color(textColorPercentage, textColorPercentage, textColorPercentage);
                    if (Level.CurrentScore == Level.MaxScore)
                        spriteBatch.DrawString(
                        spriteFont,
                        "WIN!",
                        new Vector2(viewObj.Rectangle.X, viewObj.Rectangle.Y),
                        textColor);
                    else
                        spriteBatch.DrawString(
                        spriteFont,
                        Convert.ToString(Level.CurrentScore),
                        new Vector2(viewObj.Rectangle.X, viewObj.Rectangle.Y),
                        textColor);
                    continue;
                }
                if (!Level.IdsObjects.ContainsKey(objId))
                {
                    idsViewObjects.Remove(objId);
                    continue;
                }
                
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
            if (obj is Fire)
                idsViewObjects.Add(objId, new FireUI(rectangle, texture));
        }
    }
}
