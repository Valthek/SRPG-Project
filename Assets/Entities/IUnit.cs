using Assets.Entities.Attributes;
using UnityEngine;



namespace Assets.Entities
{
    interface IUnit
    {
        Health Health { get; set; }


        void Select();
    }
}
