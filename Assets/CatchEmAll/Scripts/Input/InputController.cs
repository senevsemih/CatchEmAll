using UnityEngine;

namespace Assets.CatchEmAll.Scripts.Input
{
    public class InputController : MonoBehaviour
    {
        [SerializeField] private InputData _ınputData;

        private void Update()
        {
            _ınputData.Horizontal = UnityEngine.Input.GetAxis("Horizontal");
            _ınputData.Jump = UnityEngine.Input.GetButtonDown("Jump");

            Vector2 mousePosition = UnityEngine.Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            _ınputData.MousePosition = mousePosition;
        }
    }
}
