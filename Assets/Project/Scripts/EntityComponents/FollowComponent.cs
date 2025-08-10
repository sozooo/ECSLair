using Entitas;
using UnityEngine;

namespace Project.Scripts.EntityComponents
{
    [Game]
    public sealed class FollowComponent : IComponent
    {
        public Transform Target;
    }
}
