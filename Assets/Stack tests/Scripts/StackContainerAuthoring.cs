using Unity.Entities;
using UnityEngine;
using System.Collections.Generic;

public class StackContainerAuthoring : MonoBehaviour
{
    public class StackContainerBaker : Baker<StackContainerAuthoring>
    {
        public override void Bake(StackContainerAuthoring authoring)
        {
            var entity = GetEntity(TransformUsageFlags.Dynamic);
            var stackContainer = new StackContainer
            {
                ProcessStacks = true,
            };
            AddComponentObject(entity, stackContainer);
        }
    }
}

public class StackContainer : IComponentData // unmanaged yippeee
{
    public int FireStacks;
    public int WaterStacks;
    public int SteamStacks;
    public bool ProcessStacks = true;
}

