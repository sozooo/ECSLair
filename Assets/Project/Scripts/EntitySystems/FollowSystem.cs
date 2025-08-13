using Entitas;
using UnityEngine;

namespace Project.Scripts.EntitySystems
{
    public class FollowSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _followers;
        
        public FollowSystem(GameContext context)
        {
            _followers = context
                .GetGroup(GameMatcher.AllOf(
                    GameMatcher.Follow,
                    GameMatcher.Movable));
        }
        
        public void Execute()
        {
            foreach (GameEntity follower in _followers)
            {
                if (follower.hasMovable == false || follower.hasFollow == false) 
                    continue;
                
                Transform target = follower.follow.Target;
                Transform transform = follower.movable.Transform;

                if (target != null)
                { 
                    follower.movable.Direction= (target.position - transform.position).normalized;
                }
            }
        }
    }
}