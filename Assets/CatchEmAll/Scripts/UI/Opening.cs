using Assets.CatchEmAll.Scripts.Character;
using UnityEngine;

namespace Assets.CatchEmAll.Scripts.UI
{
    public class Opening : MonoBehaviour
    {
        [SerializeField] private GameObject _character;
        [SerializeField] private GameObject _openingUI;
        
        public void StartGame()
        {
            _character.GetComponent<CharacterManager>().enabled = true;
            _openingUI.SetActive(false);
        }
    }
}
