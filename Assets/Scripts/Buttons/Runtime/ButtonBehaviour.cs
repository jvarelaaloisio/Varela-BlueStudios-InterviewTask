using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Buttons.Runtime
{
    [RequireComponent(typeof(Button))]
    public abstract class ButtonBehaviour : MonoBehaviour
    {
        [Header("Setup")]
        [SerializeField] protected Button button;
        [SerializeField] protected TMP_Text text;
        
        [Header("Config")]
        [SerializeField] protected string namePrefix = "btn_";

        protected virtual void Reset()
        {
            button = GetComponent<Button>();
            text = GetComponentInChildren<TMP_Text>();
        }

        protected virtual void OnEnable()
        {
            if (button == null)
                Debug.LogError($"{name}: {nameof(button)} is null!");
            else
                button.onClick.AddListener(HandleClick);
        }

        protected virtual void OnDisable()
        {
            if (button)
            {
                button.onClick.RemoveListener(HandleClick);
            }
        }

        /// <summary>
        /// Changes name and Text for button
        /// </summary>
        /// <param name="content"></param>
        public virtual void SetContent(string content)
        {
            if (text) text.text = content;
            name = namePrefix + content;
        }

        /// <summary>
        /// Handles the click event on the button component
        /// </summary>
        protected abstract void HandleClick();
    }
}
