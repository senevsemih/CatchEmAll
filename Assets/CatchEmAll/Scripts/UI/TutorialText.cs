using UnityEngine;
using UnityEngine.UI;

namespace Assets.CatchEmAll.Scripts.UI
{
    public class TutorialText : MonoBehaviour
    {
        [SerializeField] private UISettings _uıSettings;
        [SerializeField] private Animator _animator;
        [SerializeField] private Text _endText;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                _animator.SetBool("Text", true);

                if (_uıSettings.Keys.Count >= 3 )
                {
                    _uıSettings.End = true;
                }
                else
                {
                    _endText.text = "You need to 3 key open the door";
                }
            }
        }
    
        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                _animator.SetBool("Text", false);
            }
        }
    }
}
