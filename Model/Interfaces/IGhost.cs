using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GhostsGame.Model.Enums;
using Microsoft.Xna.Framework;

namespace GhostsGame.Model.Interfaces
{
    public interface IGhost: IObject
    {
        public Vector2 Position { get; }
        void Attack(IWeapon weapon);
    }
}
