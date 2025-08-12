using UnityEngine;

namespace Project.Scripts.WorkObjects
{
    [CreateAssetMenu(fileName = "EntityData", menuName = "Entity/New Entity", order = 51)]
    public class EntityData : ScriptableObject
    {
        [field: SerializeField] public GameObject Prefab { get; private set; }
        [field: SerializeField] public float DefaultSpeed { get; private set; }
    }
}