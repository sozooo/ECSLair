using Entitas;

namespace Project.Scripts.HealthSystems.Components
{
    [Game]
    public class HealthComponent : IComponent
    {
        public float MaxHealth;
        public float CurrentHealth;
        public float RegenerationAmount;
    }
}