using Unity.Entities;
using UnityEngine;
using System.Collections.Generic;

public partial class StackContainerSystem : SystemBase
{
    protected override void OnUpdate()
    {
        foreach (var container in SystemAPI.Query<StackContainer>())
        {
            if (!container.ProcessStacks) continue;
            
            int steamStacksToCreate 
        }
    }
}
