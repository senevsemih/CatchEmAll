using UnityEngine;

namespace Assets.CatchEmAll.Scripts.Projectile
{
    public class ProjectileManager : MonoBehaviour
    {
        [SerializeField] private ProjectileSettings _projectileSettings;

        private Rigidbody2D _projectileRb;

        private void Awake()
        {
            _projectileRb = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            ProjectileMovement();
        }

        private void ProjectileMovement()
        {
            float angle = Mathf.Atan2(_projectileRb.velocity.y, _projectileRb.velocity.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
}
