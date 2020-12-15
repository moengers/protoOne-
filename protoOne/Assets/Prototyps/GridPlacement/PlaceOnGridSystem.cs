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
            var ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());

            Entities.ForEach((ref Translation translation, in PlaceOnGridData placeOnGridData, in NonUniformScale scale) =>
            {
                RaycastHit hit;
                var gridSize = placeOnGridData.gridSize;
                var gridSizeD2 = gridSize / 2;
                
                bool isEvenX = (scale.Value.x % 2 == 0);
                bool isEvenZ = (scale.Value.z % 2 == 0);
                
                //Calc new Position:
                if (Physics.Raycast(ray, out hit))
                {
                    var newPosition = (float3)hit.point;
                    newPosition.y += scale.Value.y * 0.5f;
                    if (isEvenX)
                    {
                        if (isEvenZ)
                        {
                            newPosition.x = Rounder.RoundToNearest(newPosition.x, gridSize);
                            newPosition.z = Rounder.RoundToNearest(newPosition.z, gridSize);
                        }
                        else
                        {
                            newPosition.x = Rounder.RoundToNearest(newPosition.x, gridSize);
                            newPosition.z = Rounder.RoundToNearest(newPosition.z + gridSizeD2, gridSize) - gridSizeD2;
                        }
                    }
                    else
                    {
                        if (isEvenZ)
                        {
                            newPosition.x = Rounder.RoundToNearest(newPosition.x + gridSizeD2, gridSize) - gridSizeD2;
                            newPosition.z = Rounder.RoundToNearest(newPosition.z, gridSize);
                        }
                        else
                        {
                            newPosition.x = Rounder.RoundToNearest(newPosition.x + gridSizeD2, gridSize) - gridSizeD2;
                            newPosition.z = Rounder.RoundToNearest(newPosition.z + gridSizeD2, gridSize) - gridSizeD2;
                        }
                    }
                    
                    //Set new Position
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
