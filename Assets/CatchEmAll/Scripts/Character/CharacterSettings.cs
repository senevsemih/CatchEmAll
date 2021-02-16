using UnityEngine;

namespace Assets.CatchEmAll.Scripts.Character
{
    [CreateAssetMenu(fileName = "New Character Settings",
        menuName = "CatchEmAll/Character Settings")]
    public class CharacterSettings : ScriptableObject
    {
        [SerializeField] private float _movementSpeed;
        [SerializeField] private float _flipSpeed;
        [SerializeField] private Quaternion _flipRotation;

        public Quaternion FlipRotation => _flipRotation;
        public float FlipSpeed => _flipSpeed;
        public float MovementSpeed => _movementSpeed;
    }
}
