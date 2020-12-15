using Unity.Entities;
using UnityEngine;

namespace GridPlacement
{
    [GenerateAuthoringComponent]
    public struct PlaceOnGridData : IComponentData
    {
        public float gridSize;  
    }
}

