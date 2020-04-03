
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;
using Random = Unity.Mathematics.Random;

namespace RotationPrototype
{
    [AlwaysSynchronizeSystem]
    public class MassivSpawnerSystem : JobComponentSystem
    {
        EndSimulationEntityCommandBufferSystem m_EndSimulationEcbSystem;
        private int i = 1;

        protected override JobHandle OnUpdate(JobHandle inputDeps)
        {

            var rand = new Random((uint)i);
        
            Entities.ForEach((ref ShowCount showCount,in MassiveSpawnerData massiveSpawnerData) =>
            {
                if(i> massiveSpawnerData.numberToInstantiate-1) return;
            
                var toInstantiate = massiveSpawnerData.ObjectToSpawn;
                var numberToInstantiate = massiveSpawnerData.numberToInstantiate;

            
                var spawnedEntity = EntityManager.Instantiate(toInstantiate);
                i++;
                showCount.counter = i;
                var asd = rand.NextFloat(1, 2);
                for (int j = 0; j < 1000; j++)
                {
                    EntityManager.SetComponentData(spawnedEntity, new Translation
                    {
                        Value = new float3(rand.NextFloat(-10f, 10f), rand.NextFloat(-10f, 10f), rand.NextFloat(-10f, 10f))
                    });
                }
            
                Debug.Log("For: " + i);
            

            }).WithStructuralChanges().Run();
            return default;
        }
    }
}

