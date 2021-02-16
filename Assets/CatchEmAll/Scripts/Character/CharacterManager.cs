using Assets.CatchEmAll.Scripts.Gun;
using Assets.CatchEmAll.Scripts.Input;
using UnityEngine;

namespace Assets.CatchEmAll.Scripts.Character
{
    public class CharacterManager : MonoBehaviour
    {
        [SerializeField] private CharacterSettings _characterSettings;
        [SerializeField] private InputData _ınputData;

        private const float FlipThreshHold = 0f;

        private GunManager _gunManager;
        
        private Rigidbody2D _characterRb;
        private Quaternion _currentRotation;

        private void Awake()
        {
            _characterRb = GetComponent<Rigidbody2D>();
            _gunManager = GetComponentInChildren<GunManager>();
            _currentRotation = transform.rotation;
        }

        private void Update()
        {
            if (UnityEngine.Input.GetMouseButtonDown(0))
            {   
                _gunManager.FireProjectile();
            }
            
            CharacterFlip(CalculateFlip());
        }

        private void FixedUpdate()
        {
            CharacterMovement(_ınputData.Horizontal);
        }

        private void CharacterMovement(float direction)
        {
            _characterRb.velocity = new Vector2(direction * Time.fixedDeltaTime * _characterSettings.MovementSpeed,
                _characterRb.velocity.y);
        }

        private void CharacterFlip(Vector2 index)
        {
            if (index.x < FlipThreshHold)
            {
                transform.rotation =
                    Quaternion.Lerp(transform.rotation,
                        _characterSettings.FlipRotation, Time.deltaTime * _characterSettings.FlipSpeed);
            }
            else if (index.x >= FlipThreshHold)
            {
                transform.rotation =
                    Quaternion.Lerp(transform.rotation,
                        _currentRotation, Time.deltaTime * _characterSettings.FlipSpeed);
            }
        }

        private Vector2 CalculateFlip()
        {
            return _ınputData.MousePosition - transform.position;
        }
    }
}
