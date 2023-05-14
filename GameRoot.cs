﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using GhostsGame.Model;
using GhostsGame.View;
using System.Collections.Generic;
using GhostsGame.Model.Enums;

namespace GhostsGame
{
    public class GameRoot : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Level level;
        private Renderer renderer;
        public GameRoot()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _graphics.PreferredBackBufferWidth = 1024;
            _graphics.PreferredBackBufferHeight = 768;
            _graphics.ApplyChanges();
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            level = new Level(new Vector2(0, 0));
            
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            renderer = new Renderer(Content, _spriteBatch, level);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            if (Keyboard.GetState().IsKeyDown(Keys.W))
                level.Player.Move(Model.Enums.Direction.Up);
            if (Keyboard.GetState().IsKeyDown(Keys.S))
                level.Player.Move(Model.Enums.Direction.Down);
            if (Keyboard.GetState().IsKeyDown(Keys.A))
                level.Player.Move(Model.Enums.Direction.Left);
            if (Keyboard.GetState().IsKeyDown(Keys.D))
                level.Player.Move(Model.Enums.Direction.Right);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DimGray);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            renderer.Update();
            _spriteBatch.End();
            
            base.Draw(gameTime);
        }
    }
}