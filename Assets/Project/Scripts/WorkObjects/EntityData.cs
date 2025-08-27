using UnityEngine;

namespace Project.Scripts.WorkObjects
{
    [CreateAssetMenu(fileName = "EntityData", menuName = "Entity/New Entity", order = 51)]
    public class EntityData : ScriptableObject
    {
        [field: SerializeField] public GameObject Prefab { get; private set; }
        [field: SerializeField] public float MaxHealth { get; private set; }
        [field: SerializeField] public float RegenerationAmount { get; private set; }
        [field: SerializeField] public float BaseDamage { get; private set; }
        [field: SerializeField] public float DefaultSpeed { get; private set; }
    }
}