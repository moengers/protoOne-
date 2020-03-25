using Unity.Entities;
using Unity.Jobs;
using Unity.Transforms;
using UnityEngine;

namespace RotationPrototype
{
    
    /*
    /// <summary>
    /// Wird auf dem Mainthread ausgeführt. Also nicht paralell bearbeitet. Ganz normal.
    /// </summary>
    [AlwaysSynchronizeSystem]
    public class RotateSystem : JobComponentSystem
    {
        protected override JobHandle OnUpdate(JobHandle inputDeps)
        {
            var deltaTime = Time.DeltaTime;
            Entities.ForEach(( Rotation rotation, RotateData rotateData) =>
            {
                rotateData.currentRotation.x += deltaTime * rotateData.speed;
                var euler = rotateData.currentRotation;
                rotation.Value = Quaternion.Euler(euler);
                
            }).Run();
            return default;
        }
    }
    */
    ///*
    /// <summary>
    /// Paralel bearbeitet und in einem neuen Thread gemacht.
    /// Thread erzeugen kostet... also nur bei aufwendigen sachen oder die von sehr vielen durchgeführt werden
    /// ref: daran etwas ändern
    /// in: davon lesen
    /// nichts: beides
    /// </summary>
    public class RotateSystem : JobComponentSystem
    {
        protected override JobHandle OnUpdate(JobHandle inputDeps)
        {
            var deltaTime = Time.DeltaTime;
            JobHandle rotateJob = Entities.ForEach((ref Unity.Transforms.Rotation rotation, ref Translation translation, in RotateData rotateData) =>
            {
                //Rotate
                Quaternion q = rotation.Value;
                var r = q.eulerAngles;
                r.y += deltaTime * rotateData.speed;
                rotation.Value = Quaternion.Euler(r);
                //Move
                translation.Value.y += deltaTime * (rotateData.speed / 100);
            }).Schedule(inputDeps);
            return rotateJob;
        }

    }//*/

}
