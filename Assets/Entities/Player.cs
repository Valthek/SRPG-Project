using System.Collections;
using System.Collections.Generic;
using Assets.Entities.Attributes;
using Assets.Entities.Interfaces;
using UnityEngine;

namespace Assets.Entities
{
    class Player : MonoBehaviour, IUnit
    {
        public Health Health { get ; set ; }
        public Material RegularMaterial { get; set; }
        public Material SelectedMaterial { get; set; }

        public void Select()
        {
           gameObject.GetComponent<MeshRenderer>().material = SelectedMaterial;
        }

        public void Deselect()
        {
            gameObject.GetComponent<MeshRenderer>().material = RegularMaterial;
        }
    }
}
