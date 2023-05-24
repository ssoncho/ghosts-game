using GhostsGame.Model.Enums;
using GhostsGame.Model.Interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhostsGame.Model
{
    public class Level
    {
        const float velocityF = 8f;
        public readonly Dictionary<int, GameObject> IdsObjects = new();
        public int PlayerId { get; private set; }
        public int TileSize { get; private set; }
        private int currentObjectId = 1;

        public Level(int tileSize)
        {
            TileSize = tileSize;
        }

        public void Update()
        {
            foreach (var gameObject in IdsObjects.Values)
            {
                gameObject.Update();
            }
        }

        public void AddObject(GameObject obj)
        {
            IdsObjects[currentObjectId] = obj;
            if (obj is Player)
                PlayerId = currentObjectId;
            currentObjectId++;
        }

        public void ChangePlayerVelocity(Direction direction)
        {
            var player = (Player)IdsObjects[PlayerId];
            if (direction == Direction.Down)
                player.Velocity += velocityF * Vector2.UnitY;
            else if (direction == Direction.Up)
                player.Velocity += -velocityF * Vector2.UnitY;
            else if (direction == Direction.Right)
                player.Velocity += velocityF * Vector2.UnitX;
            else
                player.Velocity += -velocityF * Vector2.UnitX;
        }
    }
}
