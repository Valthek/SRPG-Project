using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Entities.Interfaces
{
    interface ITile:ISelectable
    {
        [SerializeField]
        GameObject WayPoint { get; set; }
        Vector3 RealPosition { get; set; }
        Vector3 TilePosition { get; set; }
    }
}
