using System.Collections;
using System.Collections.Generic;
using Assets.Entities.Attributes;
using UnityEngine;



namespace Assets.Entities.Interfaces
{
    public interface IUnit:ISelectable
    {
        Movement Movement { get; set; }
    }
}
