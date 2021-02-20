using Assets.CatchEmAll.Scripts.Projectile;
using UnityEngine;

namespace Assets.CatchEmAll.Scripts.Box
{
    public class BoxController : MonoBehaviour
    {
        [SerializeField] private ProjectileSettings _projectileSettings;
        [SerializeField] private GameObject _destroyPrefab;

        private Animator _animator;
        private int _health = 5;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Ball"))
            {
                if (_projectileSettings.States == ProjectileStates.Default || _projectileSettings.States == ProjectileStates.Bouncy )
                {
                    _health -= 1;
                    _animator.SetTrigger("hit");
                }
                else if (_projectileSettings.States == ProjectileStates.FireBall)
                {
                    _health -= 5;
                }
            
                if (_health <= 0)
                {
                    GameObject destroyEffect = Instantiate(_destroyPrefab, transform.position, transform.rotation);
                    Destroy(destroyEffect, 5f);
                    Destroy(gameObject);
                }
            }
        }
    }
}
