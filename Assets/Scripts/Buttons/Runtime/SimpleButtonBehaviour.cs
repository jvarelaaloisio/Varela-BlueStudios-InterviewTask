using UnityEngine;

using Events.Runtime.Channels;
using Events.Runtime.Channels.Helpers;

namespace Buttons.Runtime
{
    public class SimpleButtonBehaviour : ButtonBehaviour
    {
        [Header("OnClick event")]
        [SerializeField] protected VoidChannelSo onClickChannel;
        /// <summary>
        /// Setups this button behaviour. Meant for runtime instancing
        /// </summary>
        /// <param name="title"></param>
        /// <param name="clickChannel"></param>
        public virtual void Setup(string title, VoidChannelSo clickChannel)
        {
            SetContent(title);
            onClickChannel = clickChannel;
        }

        protected override void HandleClick()
        {
            onClickChannel.TryRaiseEvent();
        }
    }
}