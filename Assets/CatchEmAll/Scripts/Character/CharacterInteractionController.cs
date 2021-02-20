using System.Collections.Generic;
using Assets.CatchEmAll.Scripts.Projectile;
using Assets.CatchEmAll.Scripts.UI;
using UnityEngine;

namespace Assets.CatchEmAll.Scripts.Character
{
    public class CharacterInteractionController : MonoBehaviour
    {
        [SerializeField] private ProjectileSettings _projectileSettings;
        [SerializeField] private UISettings _uıSettings;
        [SerializeField] private GameObject _gun;
        
        private const float LerpSpeed = 3f;

        [Header("Follow Area")] 
        [SerializeField] private List<Transform> _targets = new List<Transform>();
        [SerializeField] private List<Transform> _collectables = new List<Transform>();

        private void Update()
        {
            if (_collectables.Count <= 0) return;
            for (int i = 0; i < _collectables.Count; i++)
            {
                _collectables[i].position =
                    Vector3.Lerp(_collectables[i].position, _targets[i].position, LerpSpeed * Time.deltaTime); 
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (GetTag(other, "Collectable/Gun"))
            {
                _gun.SetActive(true);
                Destroy(other.gameObject, .1f);
            }
            
            if (GetTag(other, "Projectile/Default"))
            {
                _projectileSettings.States = ProjectileStates.Default;
                Collect(other);
            }
            
            if (GetTag(other, "Projectile/Bouncy"))
            {
                _projectileSettings.States = ProjectileStates.Bouncy;
                Collect(other);
            }
            
            if (GetTag(other, "Projectile/Fireball"))
            {
                _projectileSettings.States = ProjectileStates.FireBall;
                Collect(other);
            }

            if (GetTag(other, "Collectable/Key"))
            {
                if (!_uıSettings.Keys.Contains(other.gameObject))
                {
                    _uıSettings.Keys.Add(other.gameObject);
                }
                Destroy(other.gameObject);
            }
        }

        private void Collect(Collider2D other)
        {
            other.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            
            if (!_collectables.Contains(other.gameObject.transform))
            {
                _collectables.Add(other.gameObject.transform);
            }
        }

        private bool GetTag(Collider2D other, string otherName)
        {
            return other.gameObject.tag == otherName ? true : false;
        }
    }
}
