using Unity.Entities;

namespace RotationPrototype
{
    [GenerateAuthoringComponent]
    public struct  MassiveSpawnerData : IComponentData
    {
    
        public int numberToInstantiate;
        public Entity ObjectToSpawn;
    }
}

