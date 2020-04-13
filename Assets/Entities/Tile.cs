using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Entities.Attributes;
using Assets.Entities.Interfaces;
using UnityEngine;

namespace Assets.Entities
{
    class Tile:MonoBehaviour, ITile
    {
        public Material RegularMaterial;
        public Material SelectedMaterial;
        public GameObject TileObject;

        public TerrainAttributes TerrainAttributes { get; set; }
        public GameObject WayPoint { get; set; }
        public Vector3 TilePosition { get ; set ; }
       
        // Pathfinding nonsense
        [SerializeField] public float _movementCost;

        public float MovementCost
        {
            get => _movementCost;
            set => _movementCost = value;
        }
        public List<ITile> Neighbors { get; set; }
        public ITile PreviousNode { get; set; }
        public float gScore { get; set; }
        public float fScore { get; set; }
        public float hScore { get; set; }

        void Start()
        {
            WayPoint = gameObject.transform.Find("WayPoint").gameObject;
            PreviousNode = null;
        }

        public void Select()
        { 
            TileObject.GetComponent<MeshRenderer>().material = SelectedMaterial;
        }

        public void Deselect()
        {
            TileObject.GetComponent<MeshRenderer>().material = RegularMaterial;
        }
    }
}
