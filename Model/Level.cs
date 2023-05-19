using GhostsGame.Model.Enums;
using GhostsGame.Model.Interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhostsGame.Model
{
    public class Level
    {
        public readonly Dictionary<int, IObject> IdsObjects = new();
        public Player Player { get; set; } //Add PlayerId instead
        private int currentObjectId = 1;

        public void AddObject(IObject obj)
        {
            IdsObjects[currentObjectId] = obj;
            currentObjectId++;
        }
    }
}
