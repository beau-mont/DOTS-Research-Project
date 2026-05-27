using System;
using System.Collections.Generic;
using UnityEngine;

// public abstract class Stack
// {
//     public abstract List<StackInteraction> Interactions { get; }
//     public abstract void Effect(StackContainer container);
// }
//
// public abstract class StackInteraction
// {
//     public abstract Type StackA { get; }
//     public abstract Type StackB { get; }
//     public abstract Stack Result { get; }
// }
//
// public class SteamInteraction : StackInteraction
// {
//     private Type _stackA;
//     public override Type StackA => _stackA;
//     private Type _stackB;
//     public override Type StackB => _stackB;
//
//     private Stack _result = new SteamStack();
//     public override Stack Result => _result;
// }
//
// public class FireStack : Stack
// {
//     private List<StackInteraction> _interactions = new List<StackInteraction>{new SteamInteraction()};
//     public override List<StackInteraction> Interactions => _interactions;
//     
//     public override void Effect(StackContainer container)
//     {
//         throw new System.NotImplementedException();
//     }
// }
//
// public class WaterStack : Stack
// {
//     private List<StackInteraction> _interactions;
//     public override List<StackInteraction> Interactions => _interactions;
//     
//     public override void Effect(StackContainer container)
//     {
//         throw new System.NotImplementedException();
//     }
// }
//
// public class SteamStack : Stack
// {
//     private List<StackInteraction> _interactions;
//     public override List<StackInteraction> Interactions => _interactions;
//     
//     public override void Effect(StackContainer container)
//     {
//         throw new System.NotImplementedException();
//     }
// }