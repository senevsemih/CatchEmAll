using Assets.CatchEmAll.Scripts.Input;
using Assets.CatchEmAll.Scripts.Projectile;
using UnityEngine;

namespace Assets.CatchEmAll.Scripts.Gun
{
    public class GunManager : MonoBehaviour
    {
        [SerializeField] private ProjectileSettings _projectileSettings;
        [SerializeField] private InputData _ınputData;

        [Header("PROJECTILE")] 
        [SerializeField] private GameObject _projectilePrefab;
        [SerializeField] private Transform _projectileTransform;

        private Transform _gunPivot;

        private void Awake()
        {
            _gunPivot = GetComponentInParent<Transform>().parent;
        }
        
        private void Update()
        {
            if (UnityEngine.Input.GetMouseButtonDown(0))
            {
                if (_projectileSettings.States == ProjectileStates.Default || 
                    _projectileSettings.States == ProjectileStates.Bouncy || 
                    _projectileSettings.States == ProjectileStates.FireBall)
                {
                    FireProjectile();
                }
                else
                {
                    return;
                }
            }
            
            GunRotation();
        }

        private void GunRotation()
        {
            Vector2 distance = _ınputData.MousePosition - transform.position;
            float angle = Mathf.Atan2(distance.y, distance.x) * Mathf.Rad2Deg;
            _gunPivot.rotation = Quaternion.Euler(0f, 0f, angle); 
        }

        private void FireProjectile()
        {
            GameObject projectile = Instantiate(_projectilePrefab);
            projectile.transform.position = _projectileTransform.position;
            projectile.GetComponent<Rigidbody2D>().velocity = transform.right * _projectileSettings.ProjectileSpeed;
        }
    }
}
