using GhostsGame.Model;
using GhostsGame.Model.Enums;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhostsGame.Controller
{
    public class PlayerController
    {
        private const float velocityF = 32f;

        private readonly Level level;
        private KeyboardState previousKeyboardState;

        private event EventHandler<PlayerMovementEventArgs> PlayerMoved = delegate { };
        public PlayerController(Level level)
        {
            PlayerMoved += level.OnPlayerStartMovement;
            this.level = level;
        }

        public void Update()
        {
            var currentKeyboardState = Keyboard.GetState();
            if (currentKeyboardState.IsKeyDown(Keys.A))
                PlayerMoved.Invoke(this, new PlayerMovementEventArgs(Direction.Left));
            if (currentKeyboardState.IsKeyDown(Keys.D))
                PlayerMoved.Invoke(this, new PlayerMovementEventArgs(Direction.Right));
            if (previousKeyboardState.IsKeyDown(Keys.W) && currentKeyboardState.IsKeyUp(Keys.W))
                PlayerMoved.Invoke(this, new PlayerMovementEventArgs(Direction.Up));
            previousKeyboardState = currentKeyboardState;
        }
    }

    public class PlayerMovementEventArgs : EventArgs
    {
        public PlayerMovementEventArgs(Direction direction)
        {
            Direction = direction;
        }
        public readonly Direction Direction;
    }
}
