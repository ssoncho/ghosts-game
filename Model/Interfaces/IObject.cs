using GhostsGame.Model.Enums;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhostsGame.Model.Interfaces
{
    public interface IObject
    {
        void Move(Direction direction);
    }
}
