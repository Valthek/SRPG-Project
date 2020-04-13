using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Entities.Interfaces
{
    public interface ITile:ISelectable
    {
        [SerializeField]
        GameObject WayPoint { get; set; }
        Vector3 TilePosition { get; set; }
        float MovementCost { get; set; }

        // Pathfinding nonsense
        List<ITile> Neighbors { get; set; }
        ITile PreviousNode { get; set; }
        float gScore { get; set; }
        float fScore { get; set; }
        float hScore { get; set; }
    }
}
