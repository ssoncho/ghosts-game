﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using GhostsGame.Model;
using GhostsGame.View;
using System.Collections.Generic;
using GhostsGame.Model.Enums;
using System.Diagnostics;
using System.Threading;
using System;

namespace GhostsGame.Controller
{
    public class GameRoot : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Level level1;
        private ScreenController screenController;
        private Renderer renderer;
        private Texture2D tile;
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
            var level1Description =
                @"################
                  #              #
                  #              #
                  #              #
                  #              #
                  #              #
                  #              #
                  #  ######      #
                  #        ## #  #
                  #              #
                  #  P           #
                  ################";

            screenController = new ScreenController();
            level1 = screenController.LoadLevelFromText(level1Description);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            renderer = new Renderer(Content, _spriteBatch, level1);
            tile = Content.Load<Texture2D>("tile");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            var currentKeyboardState = Keyboard.GetState();
            // TODO: Add your update logic here
            if (currentKeyboardState.IsKeyDown(Keys.W))
                level1.Player.Move(Direction.Up);
            if (currentKeyboardState.IsKeyDown(Keys.S))
                level1.Player.Move(Direction.Down);
            if (currentKeyboardState.IsKeyDown(Keys.A))
                level1.Player.Move(Direction.Left);
            if (currentKeyboardState.IsKeyDown(Keys.D))
                level1.Player.Move(Direction.Right);

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