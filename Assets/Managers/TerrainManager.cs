using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Managers
{
    public sealed class TerrainManager
    {
        private List<GameObject> AllTiles;
        public List<GameObject> OpenTiles;
        private static readonly object _padlock = new object();

        private static TerrainManager _instance;

        private TerrainManager(List<GameObject> Tiles)
        {
            AllTiles = Tiles;
            OpenTiles = AllTiles;
        }

        public static TerrainManager GetTerrainManager(List<GameObject> tiles)
        {
            lock (_padlock)
            {
                if (_instance == null)
                {
                    _instance = new TerrainManager(tiles);
                }
                return _instance;
            }
        }

        public bool OccupyTile(GameObject tile)
        {
            var target = OpenTiles.FirstOrDefault(t => t == tile);
            if (target == null)
                return false;

            OpenTiles.Remove(tile);
            return true;
        }

    }
}
