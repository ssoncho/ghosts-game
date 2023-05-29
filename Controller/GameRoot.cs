using Microsoft.Xna.Framework;
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
        private const int tileSize = 64;
        private const int screenHeight = 768;
        private const int screenWidth = 1024;

        private GraphicsDeviceManager _graphics;
        //private SpriteBatch _spriteBatch;

        private Level level1;
        private ScreenController screenController;
        private PlayerController playerController;
        private Renderer renderer;
        public GameRoot()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _graphics.PreferredBackBufferWidth = screenWidth;
            _graphics.PreferredBackBufferHeight = screenHeight;
            _graphics.ApplyChanges();
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            var level1Description =
@"################
#  F           #
#              #
#           F  #
#   ##  P   #  #
##        #    #
#      ##      #
#    F#        #
#   ##    ##  F#
###     #    ###
#              #
################".Replace("\r\n", string.Empty);
            screenController = new ScreenController(screenWidth / tileSize, screenHeight / tileSize, tileSize);
            level1 = screenController.LoadLevelFromText(level1Description);
            playerController = new PlayerController(level1);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            renderer = new Renderer(level1);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            playerController.Update();
            level1.Update();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            // TODO: Add your drawing code here
            renderer.Update();

            base.Draw(gameTime);
        }
    }
}