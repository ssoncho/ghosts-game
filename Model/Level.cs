using GhostsGame.Controller;
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
        private const float jumpingVelocityF = 25f;
        private const int firstObjectId = 1;

        public bool IsPlayerCollided { get; private set; } = false;
        public Vector2 Gravity { get; private set; } = new Vector2(0, 2f);
        public readonly Dictionary<int, IObject> IdsObjects = new();
        private Dictionary<Direction, Vector2> directionsVectors = new() {
            { Direction.Up, -jumpingVelocityF * Vector2.UnitY },
            { Direction.Down, jumpingVelocityF * Vector2.UnitY },
            { Direction.Left, -velocityF * Vector2.UnitX },
            { Direction.Right, velocityF * Vector2.UnitX }};
        private bool isPlayerJumping = false;

        public int MaxScore { get; private set; }
        public int CurrentScore { get; private set; }
        public int PlayerId { get; private set; }
        public int TileSize { get; private set; }
        private int currentObjectId = firstObjectId;

        public Level(int tileSize)
        {
            TileSize = tileSize;
        }

        public void SetMaxScore(int maxScore)
        {
            MaxScore = maxScore;
        }

        public void Update()
        {
            var idsInitialPositions = new Dictionary<int, Vector2>();
            foreach (var id in IdsObjects.Keys)
            {
                Vector2 initialPosition = IdsObjects[id].Position;
                if (id == PlayerId && isPlayerJumping)
                    MovePlayerUpDown();
                IdsObjects[id].Update();
                if (id == PlayerId)
                    StopPlayerSideMovement();
                idsInitialPositions[id] = initialPosition;
            }
            IsPlayerCollided = false;
            var isPlayerOnGround = false;
            foreach (var firstObjectId in idsInitialPositions.Keys)
            {
                foreach (var secondObjectId in idsInitialPositions.Keys)
                {
                    if (firstObjectId == secondObjectId
                        || !IdsObjects.ContainsKey(secondObjectId) || !IdsObjects.ContainsKey(firstObjectId))
                        continue;
                    MoveBackIfCollision(
                      (idsInitialPositions[firstObjectId], firstObjectId),
                      (idsInitialPositions[secondObjectId], secondObjectId)
                    );
                    if (!IdsObjects.ContainsKey(secondObjectId))
                        continue;
                    if (!IdsObjects.ContainsKey(firstObjectId))
                        break;
                    if (firstObjectId == PlayerId
                        && IdsObjects[secondObjectId] is Tile tile
                        && !isPlayerOnGround)
                        isPlayerOnGround = IsPlayerOnGround((Player)IdsObjects[PlayerId], tile);
                }
            }

            if (IsPlayerCollided || isPlayerOnGround)
                StopPlayerMovement();
            isPlayerJumping = !isPlayerOnGround;
        }

        private void MoveBackIfCollision(
                (Vector2 InitPos, int Id) firstObjInfo,
                (Vector2 InitPos, int Id) secondObjInfo)
        {
            if (IdsObjects[firstObjInfo.Id] is ISolid firstSolidObj && IdsObjects[secondObjInfo.Id] is ISolid secondSolidObj)
            {
                var oppositeDirection = new Vector2(0, 0);
                while (RectangleCollider.IsCollided(firstSolidObj.Collider, secondSolidObj.Collider))
                {
                    if (firstSolidObj is Player || secondSolidObj is Player)
                    {
                        IsPlayerCollided = true;
                        if (firstSolidObj is Fire || secondSolidObj is Fire)
                        {
                            if (firstSolidObj is Fire)
                                Collect(firstObjInfo.Id);
                            else
                                Collect(secondObjInfo.Id);
                            CurrentScore++;
                            return;
                        }
                    }
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
        }

        private bool IsPlayerOnGround(Player player, ISolid solidObj) =>
            RectangleCollider.IsPlayerOnTopOf(player.Collider, solidObj.Collider);

        public void AddObject(IObject obj)
        {
            IdsObjects[currentObjectId] = obj;
            if (obj is Player)
                PlayerId = currentObjectId;
            currentObjectId++;
        }

        public void ChangePlayerVelocity(Direction direction)
        {
            ChangePlayerVelocity(directionsVectors[direction]);
        }

        public void ChangePlayerVelocity(Vector2 newVelocity)
        {
            var player = (Player)IdsObjects[PlayerId];

            player.Velocity += newVelocity;
        }

        public void StopPlayerMovement()
        {
            var player = (Player)IdsObjects[PlayerId];

            player.Velocity = Vector2.Zero;
        }
        public void StopPlayerSideMovement()
        {
            var player = (Player)IdsObjects[PlayerId];

            player.Velocity = new Vector2(0, player.Velocity.Y);
        }

        public void OnPlayerStartMovement(object sender, PlayerMovementEventArgs e)
        {
            if (!isPlayerJumping || e.Direction == Direction.Left || e.Direction == Direction.Right)
                ChangePlayerVelocity(e.Direction);
            if (e.Direction == Direction.Up || e.Direction == Direction.Down)
                isPlayerJumping = true;
        }

        public void MovePlayerUpDown()
        {
            ChangePlayerVelocity(Gravity);
        }

        private void Collect(int objId) =>
            IdsObjects.Remove(objId);
    }
}
