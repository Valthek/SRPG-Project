using Assets.Entities.Attributes;
using Assets.Entities.Interfaces;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Entities
{
    public class Player : MonoBehaviour, IUnit
    {
        public Material RegularMaterial;
        public Material SelectedMaterial;

        public Movement Movement { get; set; }

        public Health Health { get; set; }
        
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
