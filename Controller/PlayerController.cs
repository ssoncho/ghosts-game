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
        private bool isJumping = false;
        private Vector2 playerMaxHeight = new Vector2(0, 256f);
        private Vector2 positionBeforeJump;
        private Vector2 velocityDuringJump;

        private Dictionary<Direction, Vector2> jumpingDirectionsVectors = new() {
        { Direction.Up, -velocityF * Vector2.UnitY },
        { Direction.Down, velocityF * Vector2.UnitY }};
        public PlayerController(Level level)
        {
            this.level = level;
        }

        public void Move()
        {
            var currentKeyboardState = Keyboard.GetState();
            if (currentKeyboardState.IsKeyDown(Keys.A))
                level.ChangePlayerVelocity(Direction.Left);
            if (currentKeyboardState.IsKeyDown(Keys.D))
                level.ChangePlayerVelocity(Direction.Right);
        }

        public void Jump()
        {
            //what should i do if collision is detected?
            var currentKeyboardState = Keyboard.GetState();
            if (currentKeyboardState.IsKeyDown(Keys.W) && !isJumping)
            {
                positionBeforeJump = level.IdsObjects[level.PlayerId].Position;
                velocityDuringJump = jumpingDirectionsVectors[Direction.Up];
                isJumping = true;
                level.ChangePlayerVelocity(velocityDuringJump);
                Debug.Write("Started Jumping Position before jump: ");
                Debug.WriteLine(positionBeforeJump);
                Debug.Write(level.IdsObjects[level.PlayerId].Position.Y);
                Debug.Write(" ");
                Debug.WriteLine(positionBeforeJump.Y - playerMaxHeight.Y);
            }
            else if (isJumping && level.IdsObjects[level.PlayerId].Position.Y == positionBeforeJump.Y)
            {
                isJumping = false;
                Debug.WriteLine("On the ground");
            }
            else if (!level.IsPlayerCollided && isJumping && level.IdsObjects[level.PlayerId].Position.Y > positionBeforeJump.Y - playerMaxHeight.Y) 
            {
                velocityDuringJump += level.Gravity;
                level.ChangePlayerVelocity(velocityDuringJump);
                Debug.Write("Jumping ");
                Debug.Write(level.IdsObjects[level.PlayerId].Position.Y);
                Debug.Write(" ");
                Debug.Write(positionBeforeJump.Y - playerMaxHeight.Y);
                Debug.Write(level.IsPlayerCollided);
                Debug.WriteLine("");
            }
            else if (level.IsPlayerCollided || isJumping && level.IdsObjects[level.PlayerId].Position.Y <= positionBeforeJump.Y - playerMaxHeight.Y)
            {
                if (!level.IsPlayerCollided)
                    level.IdsObjects[level.PlayerId].Move(positionBeforeJump - playerMaxHeight);
                velocityDuringJump = level.Gravity;
                level.ChangePlayerVelocity(velocityDuringJump);
                Debug.Write("On the top of jumping ");
                Debug.Write(level.IdsObjects[level.PlayerId].Position.Y);
                Debug.Write(" ");
                Debug.WriteLine(positionBeforeJump.Y - playerMaxHeight.Y);
            }
            //if (isJumping)
                //Debug.WriteLine($"{level.IdsObjects[level.PlayerId].Position}. {level.IdsObjects[level.PlayerId].Velocity}");
        }
    }
}
