using UnityEngine;

namespace Assets.CatchEmAll.Scripts.Projectile
{
    [CreateAssetMenu(fileName = "New Projectile Settings",
        menuName = "CatchEmAll/Projectile Settings")]
    public class ProjectileSettings : ScriptableObject
    {
        [SerializeField] private ProjectileStates ProjectileStates
            = ProjectileStates.Non;
        [SerializeField] private float _projectileSpeed;
        [SerializeField] private float _bouncyIndex;


        public ProjectileStates States
        {
            get => ProjectileStates;
            set => ProjectileStates = value;
        }

        public float ProjectileSpeed => _projectileSpeed;
        public float BouncyIndex => _bouncyIndex;
    }
}

public enum ProjectileStates
{
    Non,
    Default,
    Bouncy,
    FireBall
}
