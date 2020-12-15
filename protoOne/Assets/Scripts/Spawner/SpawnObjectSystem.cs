using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;
public class NewBehaviourScript : JobComponentSystem
{
    EndSimulationEntityCommandBufferSystem m_EndSimulationEcbSystem;
    private int i = 1;

    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        Entities.ForEach((ref SpawnObjectData spawnData) =>
        {
            if(spawnData.queueCount == 0) return;

            for (int i = 0; i < spawnData.queueCount; i++)
            {
                /*var prefab = spawnData.objectToSpawn.Dequeue();
                var position = spawnData.pos.Dequeue();
                var count = spawnData.numberToInstantiate.Dequeue();

                for (int j = 0; j < count; j++)
                {
                    Spawn();
                }*/

            }
            /*
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

            if (i % 1000 == 0)
            {
                Debug.Log("For: " + i);
            }
            
            */
        }).WithStructuralChanges().Run();
        return default;
    }
    
    private void Spawn(){
        
    }
}
