using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Entities.Interfaces;
using UnityEngine;

namespace Assets.Helpers
{
    public class PathfindingHelper
    {
        public static List<ITile> FindPath(ITile start, ITile destination, List<ITile> environment)
        {
            foreach (ITile t in environment)
            {
                t.gScore = 10000.0f;
            }

            start.PreviousNode = null;
            start.gScore = 0;
            start.fScore = Vector3.Distance(start.TilePosition, destination.TilePosition);

            // Test if we actually can have a valid path
            if (!environment.Contains(start) || !environment.Contains(destination))
                return null;

            List<ITile> openSet = new List<ITile>
            {
                start
            };

            while (openSet.Count > 0)
            {
                var currentNode = openSet.OrderBy(n => n.fScore).FirstOrDefault();
                if (currentNode == destination)
                    return ReconstructPath(start, currentNode);
                openSet.Remove(currentNode);
                foreach (var node in currentNode.Neighbors)
                {
                    var tentativeGScore = currentNode.gScore + CalculateDistance(currentNode, node);
                    if (tentativeGScore < node.gScore)
                    {
                        node.PreviousNode = currentNode;
                        node.gScore = tentativeGScore;
                        node.fScore = node.gScore + Vector3.Distance(node.TilePosition, destination.TilePosition);
                        if (!openSet.Contains(node))
                        {
                            openSet.Add(node);
                        }
                    }
                }
            }
            return null;
        }

        private static List<ITile> ReconstructPath(ITile origin, ITile current)
        {
            List<ITile> path = new List<ITile>()
            {
                current
            };
            while (!path.Contains(origin))
            {
                path.Add(current.PreviousNode);
                current = current.PreviousNode;

            }
            path.Reverse();
            foreach(ITile t in path)
                Debug.Log($"Node: {t.TilePosition}");
            return path;
        }

        private static float CalculateDistance(ITile start, ITile destination)
        {
            var absoluteDistance = Vector3.Distance(start.TilePosition, destination.TilePosition);
            var weightedDistance = absoluteDistance * destination.MovementCost;
            return weightedDistance;
        }

    }
}
