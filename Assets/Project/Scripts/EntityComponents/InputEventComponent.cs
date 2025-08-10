using Entitas;
using UnityEngine;

namespace Project.Scripts.EntityComponents
{
    [Game]
    public sealed class InputEventComponent : IComponent
    {
        public Vector2 Direction;
    }
}