using Entitas;
using Project.Scripts.WeaponSystems.Data;
using UnityEngine;

namespace Project.Scripts.WeaponSystems.Components
{
    [Game]
    public class WeaponComponent : IComponent
    {
        public Transform Transform;
        public ITargetProvider TargetProvider;
    }
}