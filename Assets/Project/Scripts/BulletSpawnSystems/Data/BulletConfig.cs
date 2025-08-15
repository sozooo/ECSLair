using System.Collections.Generic;
using UnityEngine;

namespace Project.Scripts.BulletSpawnSystems.Data
{
    [CreateAssetMenu(fileName = "BulletConfig", menuName = "Entity/New BulletConfig", order = 51)]
    public class BulletConfig : ScriptableObject
    {
        [field: SerializeField] public List<BulletData> BulletDatas { get; private set; }
    }
}