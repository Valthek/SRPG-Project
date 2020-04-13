using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Entities.Interfaces;
using Assets.Helpers;
using UnityEngine;

namespace Assets.Entities.Attributes
{
    public class Movement
    {
        public List<ITile> Path { get; set; }
        public ITile CurrentLocation { get; set; }
        public ITile NewDestination { get; set; }
        public float MovementErrorMargin { get; set; }

        public Movement(float movementErrorMargin)
        {
            Path = new List<ITile>();
            MovementErrorMargin = movementErrorMargin;
        }

        public void SetDestination(ITile destination, List<ITile> field)
        {
            NewDestination = destination;
            CalculatePath(field);
        }

        public void StepToDestination()
        {
            throw new System.NotImplementedException();
        }

        private void CalculatePath(List<ITile> field)
        {
            Path = PathfindingHelper.FindPath(CurrentLocation, NewDestination, field);
        }

    }
}
