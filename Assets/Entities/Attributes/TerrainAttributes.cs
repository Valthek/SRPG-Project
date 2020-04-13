using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Entities.Attributes
{
    /// <summary>
    /// Basic attributes of a specific tile (Movement Cost, blocking, etc)
    /// </summary>
    class TerrainAttributes
    {
        public int MovementCost { get; set; }
        public bool IsPassable { get; set; }
    }
}
