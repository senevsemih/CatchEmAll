using Assets.CatchEmAll.Scripts.Input;
using UnityEngine;

namespace Assets.CatchEmAll.Scripts.Character
{
    public class CharacterManager : MonoBehaviour
    {
        [Header("SO")]
        [SerializeField] private CharacterSettings _characterSettings;
        [SerializeField] private InputData _ınputData;

        [Header("Ground Check")]
        [SerializeField] private Transform _groundCheckPoint;

        private const float FlipThreshHold = 0f;
        private const float JumpThreshHold = 0f;

        private Rigidbody2D _characterRb;
        private Quaternion _currentRotation;
        private Animator _animator;

        private bool _isGrounded;
        private float _hangCounter;
        private float _jumpBufferCount;

        private void Awake()
        {
            _characterRb = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();
            _currentRotation = transform.rotation;
        }

        private void Update()
        {
            CharacterFlip(CalculateFlip());

            _isGrounded = Ground();

            CharacterJump(_ınputData.Jump);
        }

        private void FixedUpdate()
        {
            CharacterMovement(_ınputData.Horizontal);
        }

        private void CharacterMovement(float direction)
        {
            _characterRb.velocity = new Vector2(direction * Time.fixedDeltaTime * _characterSettings.MovementSpeed,
                _characterRb.velocity.y);
            _animator.SetFloat("Run", Mathf.Abs(direction));
        }

        private void CharacterJump(bool jump)
        {
            if (_isGrounded)
            {
                _hangCounter = _characterSettings.HangTime;
            }
            else
            {
                _hangCounter -= Time.deltaTime;
            }

            if (jump)
            {
                _jumpBufferCount = _characterSettings.JumpBufferLength;
            }
            else
            {
                _jumpBufferCount -= Time.deltaTime;
            }
            
            if (_jumpBufferCount >= JumpThreshHold && _hangCounter > JumpThreshHold)
            {
                _characterRb.velocity = new Vector2(_characterRb.velocity.x,
                    _characterSettings.JumpForce);
                _jumpBufferCount = JumpThreshHold;
            }
            
            if (UnityEngine.Input.GetButtonUp("Jump") && _characterRb.velocity.y > 0)
            {
                _characterRb.velocity = new Vector2(_characterRb.velocity.x,
                    _characterRb.velocity.y * _characterSettings.JumpBuff);
            }
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

        private bool Ground()
        {
            return Physics2D.OverlapCircle(_groundCheckPoint.position,
                .1f, _characterSettings.WhatIsGround);
        }
    }
}
