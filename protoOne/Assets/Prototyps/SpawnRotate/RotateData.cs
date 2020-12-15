using Unity.Entities;

namespace RotationPrototype
{
    [GenerateAuthoringComponent]
    public struct RotateData : IComponentData
    {
        public float speed;
    }
}

