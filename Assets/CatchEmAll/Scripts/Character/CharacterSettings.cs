using UnityEngine;

namespace Assets.CatchEmAll.Scripts.Character
{
    [CreateAssetMenu(fileName = "New Character Settings",
        menuName = "CatchEmAll/Character Settings")]
    public class CharacterSettings : ScriptableObject
    {
        [Range(0, 200)]
        [SerializeField] private float _movementSpeed;
        [Range(0, 15)]
        [SerializeField] private float _jumpForce;
        [Range(0, 30)]
        [SerializeField] private float _flipSpeed;
        [Range(0, 2)]
        [SerializeField] private float _hangTime;
        [Range(0, 2)]
        [SerializeField] private float _jumpBufferLength;
        [Range(0, 2)]
        [SerializeField] private float _jumpBuff;
        
        [SerializeField] private Quaternion _flipRotation;
        [SerializeField] private LayerMask _whatIsGround;

        public Quaternion FlipRotation => _flipRotation;
        public float FlipSpeed => _flipSpeed;
        public float MovementSpeed => _movementSpeed;
        public LayerMask WhatIsGround => _whatIsGround;
        public float JumpForce => _jumpForce;
        public float HangTime => _hangTime;
        public float JumpBufferLength => _jumpBufferLength;
        public float JumpBuff => _jumpBuff;
    }
}
