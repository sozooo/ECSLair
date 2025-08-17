using Entitas;
using UnityEngine;

namespace Project.Scripts.WeaponSystems
{
    public class WeaponSteering : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _weaponGroup;

        public WeaponSteering(GameContext gameContext)
        {
            _weaponGroup = gameContext.GetGroup(GameMatcher.Weapon);
        }
        
        public void Execute()
        {
            foreach (GameEntity entity in _weaponGroup)
            {
                Transform target = entity.weapon.TargetProvider.Target;
                entity.weapon.Transform.LookAt(target);
            }
        }
    }
}