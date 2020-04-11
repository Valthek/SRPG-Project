using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Entities.Interfaces;
using UnityEngine;

namespace Assets.Entities
{
    class Tile:MonoBehaviour, ITile
    {
        public Material RegularMaterial;
        public Material SelectedMaterial;
        public GameObject TileObject;

        public GameObject WayPoint { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Vector3 RealPosition { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Vector3 TilePosition { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

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
