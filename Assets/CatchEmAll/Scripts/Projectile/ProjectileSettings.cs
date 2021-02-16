using UnityEngine;

namespace Assets.CatchEmAll.Scripts.Projectile
{
    [CreateAssetMenu(fileName = "New Projectile Settings",
        menuName = "CatchEmAll/Projectile Settings")]
    public class ProjectileSettings : ScriptableObject
    {
        [SerializeField] private ProjectileStates ProjectileStates
            = ProjectileStates.Default;
        [SerializeField] private float _projectileSpeed;
        [SerializeField] private float _projectileAngle;
        
        
        public ProjectileStates States
        {
            get => ProjectileStates;
            set => ProjectileStates = value;
        }

        public float ProjectileSpeed => _projectileSpeed;
        public float ProjectileAngle => _projectileAngle;
    }
}

public enum ProjectileStates
{
    Default,
    Bouncy,
    FireBall
}
