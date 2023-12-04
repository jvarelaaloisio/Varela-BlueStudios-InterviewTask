using UnityEngine;
using UnityEngine.UI;

using TMPro;

using Events.Runtime.Channels;
using Events.Runtime.Channels.Helpers;

namespace Menus.Runtime
{
    [RequireComponent(typeof(Button))]
    public abstract class ButtonBehaviour : MonoBehaviour
    {
        [Header("Setup")]
        [SerializeField] protected Button button;
        [SerializeField] protected TMP_Text text;
        
        [Header("OnClick event")]
        [SerializeField] protected VoidChannelSo onClickChannel;
        
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
        /// <param name="title"></param>
        public virtual void SetTitle(string title)
        {
            if (text) text.text = title;
            name = namePrefix + title;
        }

        /// <summary>
        /// Handles the click event on the button component
        /// </summary>
        protected virtual void HandleClick()
        {
            onClickChannel.TryRaiseEvent();
        }
    }
}
