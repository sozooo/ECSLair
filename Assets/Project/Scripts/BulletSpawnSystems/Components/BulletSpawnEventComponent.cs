using Entitas;
using Project.Scripts.BulletSpawnSystems.Data;
using UnityEngine;

namespace Project.Scripts.BulletSpawnSystems.Components
{
    [Events]
    public sealed class BulletSpawnEventComponent : IComponent
    {
        public BulletData BulletData;
        public Vector2 Position;
        public Quaternion Rotation;
    }
}