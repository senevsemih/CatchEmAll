using System.Collections.Generic;
using UnityEngine;

namespace Assets.CatchEmAll.Scripts.UI
{
    [CreateAssetMenu(fileName = "New UI Settings",
        menuName = "CatchEmAll/UI Settings")]
    public class UISettings : ScriptableObject
    {
        [SerializeField] private List<GameObject> _keys;
        [SerializeField] private bool _end;

        public List<GameObject> Keys
        {
            get => _keys;
            set => _keys = value;
        }

        public bool End
        {
            get => _end;
            set => _end = value;
        }
    }
}
