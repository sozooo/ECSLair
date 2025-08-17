using UnityEngine;

namespace Project.Scripts.WeaponSystems.Data
{
    public interface ITargetProvider
    {
        public Transform Target { get; }
    }
}