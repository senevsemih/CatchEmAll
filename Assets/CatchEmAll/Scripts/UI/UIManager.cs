using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.CatchEmAll.Scripts.UI
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private UISettings _uıSettings;
        [SerializeField] private GameObject[] _keyIcons;
        [SerializeField] private GameObject _endScene;

        private void Update()
        {
            if (_uıSettings.Keys.Count == 0) return;
            for (int i = 0; i < _uıSettings.Keys.Count; i++)
            {
                _keyIcons[i].SetActive(true);
            }

            if (_uıSettings.End)
            {
                TheEnd();
            }
        }

        private void TheEnd()
        {
            _endScene.SetActive(true);
            Invoke("LoadScene", 15f);
        }

        private void LoadScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}

