using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

[GenerateAuthoringComponent]
public struct SpawnObjectData : IComponentData
{
    //private const int maxSpawn = 5;
    public int queueCount;
    //public fixed int numberToInstantiate[5];
    public Entity[] objectToSpawn;
    public Vector3[] pos;

    public void AddObjectToSpawn(Entity prefab, int count, Vector3 position)
    {
        //objectToSpawn.Enqueue(prefab);
        //numberToInstantiate.Enqueue(count);
        //pos.Enqueue(position);
        //queueCount++;
    }
}
