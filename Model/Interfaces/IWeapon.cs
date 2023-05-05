using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhostsGame.Model.Interfaces
{
    public interface IWeapon
    {
        Player Owner { get; }
    }
}
