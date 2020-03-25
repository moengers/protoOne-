using Unity.Entities;

namespace RotationPrototype
{
    [GenerateAuthoringComponent]
    public struct ShowCount : IComponentData
    {
        public int counter;

    }
}
