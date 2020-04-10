using Assets.Entities.Attributes;
using UnityEngine;



namespace Assets.Entities.Interfaces
{
    interface IUnit
    {
        Health Health { get; set; }

        Movement Movement { get; set; }

        [SerializeField]
        Material RegularMaterial { get; set; }
        [SerializeField]
        Material SelectedMaterial { get; set; }

        void Select();
        void Deselect();
    }
}
