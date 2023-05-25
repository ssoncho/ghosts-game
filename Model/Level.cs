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
        private Dictionary<Direction, Vector2> directionsVectors = new() {
            { Direction.Up, -velocityF * Vector2.UnitY },
            { Direction.Down, velocityF * Vector2.UnitY },
            { Direction.Left, -velocityF * Vector2.UnitX },
            { Direction.Right, velocityF * Vector2.UnitX },};
        public int PlayerId { get; private set; }
        public int TileSize { get; private set; }
        private int currentObjectId = 1;

        public Level(int tileSize)
        {
            TileSize = tileSize;
        }

        public void Update()
        {
            //add collisions
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

            player.Velocity += directionsVectors[direction];
        }

        private bool IsPlayerCollided(Player player)
        {
            var isCollided = false;
            foreach (var obj in IdsObjects.Values)
            {
                if (obj is ISolid solidObj)
                {
                    if (!(solidObj is Player) && RectangleCollider.IsCollided(solidObj.Collider, player.Collider))
                    {
                        isCollided = true;
                        break;
                    }
                }
            }
            return isCollided;
        }
    }
}
