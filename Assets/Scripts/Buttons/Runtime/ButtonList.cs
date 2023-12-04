using System.Collections.Generic;
using System.Linq;

using UnityEngine;
using UnityEngine.EventSystems;

namespace Buttons.Runtime
{
    public class ButtonList : MonoBehaviour
    {
        [Header("Config")]
        [SerializeField] private ButtonConfig[] configs;

        private readonly List<ButtonBehaviour> _buttons = new();

        private void OnEnable()
        {
            SetFirstButtonAsSelected();
        }

        private void Start()
        {
            foreach (var config in configs)
            {
                var button = config.Instantiate(Vector3.zero, Quaternion.identity, transform);
                _buttons.Add(button);
            }
            SetFirstButtonAsSelected();
        }

        private void SetFirstButtonAsSelected()
        {
            if (_buttons.Any())
                EventSystem.current.SetSelectedGameObject(_buttons.First().gameObject);
        }
    }
}