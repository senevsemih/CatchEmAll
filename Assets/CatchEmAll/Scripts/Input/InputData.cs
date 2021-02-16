using UnityEngine;

namespace Assets.CatchEmAll.Scripts.Input
{
    [CreateAssetMenu(fileName = "New Input Data", menuName = "CatchEmAll/Input Data", order = 1)]
    public class InputData : ScriptableObject
    {
        [SerializeField] private float _horizontal;
        [SerializeField] private Vector2 _mousePosition;

        public Vector2 MousePosition
        {
            get => _mousePosition;
            set => _mousePosition = value;
        }

        public float Horizontal
        {
            get => _horizontal;
            set => _horizontal = value;
        }
    } 
}
