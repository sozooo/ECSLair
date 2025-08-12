using System.Collections.Generic;

namespace Project.Scripts.WorkObjects.WeightedPicker
{
    public class WeightedRandomPicker<T>
        where T : ISpawnData
    {
        private readonly List<T> _items;
        private readonly float _totalWeight;
        
        public WeightedRandomPicker(List<T> items)
        {
            _items = items;
            
            foreach (var item in _items)
            {
                _totalWeight += item.Weight;
            }
        }
        
        public T Pick()
        {
            if (_items.Count == 0)
                throw new System.InvalidOperationException("Cannot pick from an empty list.");

            float randomValue = UnityEngine.Random.Range(0f, _totalWeight);
            float cumulativeWeight = 0f;

            foreach (var item in _items)
            {
                cumulativeWeight += item.Weight;
                
                if (randomValue < cumulativeWeight)
                    return item;
            }

            return _items[^1];
        }
    }
}