using Unity.Entities;
using Unity.Burst;
using Unity.Collections;
using Unity.Physics;
using Unity.Physics.Systems;
using UnityEngine;

public struct CubeComponent : IComponentData
{
    public int CountValue;
}

public class CubeComponentAuthoring : MonoBehaviour
{
    public class CubeComponentBaker : Baker<CubeComponentAuthoring>
    {
        public override void Bake(CubeComponentAuthoring authoring)
        {
            var entity = GetEntity(TransformUsageFlags.Dynamic);
            AddComponent<CubeComponent>(entity);
        }
    }
}

[UpdateInGroup(typeof(PhysicsSystemGroup))]
[UpdateAfter(typeof(PhysicsSimulationGroup))]
[UpdateBefore(typeof(AfterPhysicsSystemGroup))]
public partial struct CollisionDetectionSystem : ISystem
{
    [BurstCompile]
    public void OnCreate(ref SystemState state)
    {
        state.RequireForUpdate<SimulationSingleton>();
    }

    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        CollisionDetectionJob detectionJob = new()
        {
            CubeLookup = SystemAPI.GetComponentLookup<CubeComponent>()
        };
        
        var simulationSingleton = SystemAPI.GetSingleton<SimulationSingleton>();
        state.Dependency = detectionJob.Schedule(simulationSingleton, state.Dependency);
    }
}

[BurstCompile]
public struct CollisionDetectionJob : ICollisionEventsJob
{
    public ComponentLookup<CubeComponent> CubeLookup;
        
    public void Execute(CollisionEvent collisionEvent)
    {
        Entity cubeEntity;
        Entity otherEntity;
        
        if (CubeLookup.HasComponent(collisionEvent.EntityA))
        {
            cubeEntity = collisionEvent.EntityA;
            otherEntity = collisionEvent.EntityB;
        }
        else if (CubeLookup.HasComponent(collisionEvent.EntityB))
        {
            cubeEntity = collisionEvent.EntityB;
            otherEntity = collisionEvent.EntityA;
        }
        else return;
        
        var cubeComponent = CubeLookup.GetRefRW(cubeEntity);
        cubeComponent.ValueRW.CountValue++;
    }
}