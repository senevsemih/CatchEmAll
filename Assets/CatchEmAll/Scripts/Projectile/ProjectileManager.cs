using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

namespace Assets.CatchEmAll.Scripts.Projectile
{
    public class ProjectileManager : MonoBehaviour
    {
        [SerializeField] private ProjectileSettings _projectileSettings;

        private Rigidbody2D _projectileRb;
        
        [SerializeField] private GameObject _particleSystem;
        [SerializeField] private GameObject _light;

        private void Awake()
        {
            _projectileRb = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            ProjectileMovement();
            ChangeStates();
        }

        private void ProjectileMovement()
        {
            float angle = Mathf.Atan2(_projectileRb.velocity.y, _projectileRb.velocity.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }

        private void ChangeStates()
        {
            switch (_projectileSettings.States)
            {
                case ProjectileStates.Non:
                    break;
                case ProjectileStates.Default:
                    _projectileRb.sharedMaterial.bounciness = 0.0f;
                    Destroy(gameObject, 3f);
                    break;
                case ProjectileStates.Bouncy:
                    _projectileRb.sharedMaterial.bounciness = _projectileSettings.BouncyIndex;
                    Destroy(gameObject, 4f);
                    break;
                case ProjectileStates.FireBall:
                    _particleSystem.SetActive(true);
                    _light.SetActive(true);
                    Destroy(gameObject, 5f);
                    break;
            }
        }
    }
}
