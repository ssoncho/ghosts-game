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
        private const float velocityF = 8f;
        private const int firstObjectId = 1;
        public readonly Dictionary<int, IObject> IdsObjects = new();
        private Dictionary<Direction, Vector2> directionsVectors = new() {
            { Direction.Up, -velocityF * Vector2.UnitY },
            { Direction.Down, velocityF * Vector2.UnitY },
            { Direction.Left, -velocityF * Vector2.UnitX },
            { Direction.Right, velocityF * Vector2.UnitX },};
        public int PlayerId { get; private set; }
        public int TileSize { get; private set; }
        private int currentObjectId = firstObjectId;

        public Level(int tileSize)
        {
            TileSize = tileSize;
        }

        public void Update()
        {
            var idsInitialPositions = new Dictionary<int, Vector2>();
            foreach (var id in IdsObjects.Keys)
            {
                Vector2 initialPosition = IdsObjects[id].Position;
                IdsObjects[id].Update();
                idsInitialPositions[id] = initialPosition;
            }
            foreach (var firstObjectId in idsInitialPositions.Keys)
            {
                foreach (var secondObjectId in idsInitialPositions.Keys)
                {
                    if (firstObjectId == secondObjectId)
                        continue;
                    MoveIfCollision(
                      (idsInitialPositions[firstObjectId], firstObjectId),
                      (idsInitialPositions[secondObjectId], secondObjectId)
                    );
                }
            }
            //foreach (var gameObject in IdsObjects.Values)
            //{
            //    gameObject.Update();
            //}
        }

        private void MoveIfCollision(
                (Vector2 InitPos, int Id) firstObjInfo,
                (Vector2 InitPos, int Id) secondObjInfo)
        {
            bool isCollided = false;
            if (IdsObjects[firstObjInfo.Id] is ISolid firstSolidObj && IdsObjects[secondObjInfo.Id] is ISolid secondSolidObj)
            {
                var oppositeDirection = new Vector2(0, 0);
                while (RectangleCollider.IsCollided(firstSolidObj.Collider, secondSolidObj.Collider))
                {
                    isCollided = true;
                    if (firstObjInfo.InitPos != IdsObjects[firstObjInfo.Id].Position)
                    {
                        oppositeDirection = IdsObjects[firstObjInfo.Id].Position - firstObjInfo.InitPos;
                        oppositeDirection.Normalize();
                        IdsObjects[firstObjInfo.Id].Move(IdsObjects[firstObjInfo.Id].Position - oppositeDirection);
                    }
                    if (secondObjInfo.InitPos != IdsObjects[secondObjInfo.Id].Position)
                    {
                        oppositeDirection = IdsObjects[secondObjInfo.Id].Position - secondObjInfo.InitPos;
                        oppositeDirection.Normalize();
                        IdsObjects[secondObjInfo.Id].Move(IdsObjects[secondObjInfo.Id].Position - oppositeDirection);
                    }
                }
            }
            if (isCollided)
            {
                //
            }
        }

        public void AddObject(IObject obj)
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
