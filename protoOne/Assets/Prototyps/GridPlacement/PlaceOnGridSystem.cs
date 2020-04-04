using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GridPlacement
{
    [AlwaysSynchronizeSystem]
    public class PlaceOnGridSystem : JobComponentSystem
    {
        
        InputMaster inputMaster = new InputMaster();
        protected override JobHandle OnUpdate(JobHandle inputDeps)
        {

            Entities.ForEach((ref Translation translation, in PlaceOnGridData placeOnGridData) =>
            {
                var ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
                RaycastHit hit;
                var gridSize = placeOnGridData.gridSize;
                var gridSizeD2 = gridSize / 2;
                if (Physics.Raycast(ray, out hit))
                {
                    //Debug.Log("Hit");
                    var newPosition = (float3)hit.point;
                    newPosition.y = 0.5f;
                    newPosition.x = Rounder.RoundToNearest(newPosition.x + gridSizeD2, gridSize) - gridSizeD2;
                    newPosition.z = Rounder.RoundToNearest(newPosition.z + gridSizeD2, gridSize) - gridSizeD2;
                    translation.Value.xyz = newPosition;
                }
            }).WithStructuralChanges().Run();
            
            return inputDeps;
        }
    }

}

public class Rounder
{
    public static float RoundToNearest(float value, float steps)
    {
        return (float) Math.Round(value / steps) * steps;
    }
}
