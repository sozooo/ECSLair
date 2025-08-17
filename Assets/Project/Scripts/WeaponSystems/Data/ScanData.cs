using System;
using UnityEngine;

namespace Project.Scripts.WeaponSystems.Data
{
    [Serializable]
    public struct ScanData
    {
        [field: SerializeField] public Transform Center { get; private set; }
        [field: SerializeField] public float Radius { get; private set; }
        [field: SerializeField] public int MaxTargetCount { get; private set; }
        [field: SerializeField] public LayerMask LayerMask { get; private set; }
    }
}