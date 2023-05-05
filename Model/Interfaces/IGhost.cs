using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GhostsGame.Model.Enums;

namespace GhostsGame.Model.Interfaces
{
    public interface IGhost
    {
        void Move(Direction direction);
        void Attack(IWeapon weapon);
    }
}
