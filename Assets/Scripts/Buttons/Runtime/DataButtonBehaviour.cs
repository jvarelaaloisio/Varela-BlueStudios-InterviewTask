using UnityEngine;

using Events.Runtime.Channels;
using Events.Runtime.Channels.Helpers;

namespace Buttons.Runtime
{
    public abstract class DataButtonBehaviour<T> : ButtonBehaviour
    {
        [Header("OnClick event")]
        [SerializeField] protected T data;
        [SerializeField] protected ChannelSo<T> onClickChannel;

        /// <summary>
        /// Setups this button behaviour. Meant for runtime instancing
        /// </summary>
        /// <param name="title"></param>
        /// <param name="clickChannel"></param>
        /// <param name="clickEventData"></param>
        public virtual void Setup(string title, ChannelSo<T> clickChannel, T clickEventData)
        {
            SetContent(title);
            onClickChannel = clickChannel;
            data = clickEventData;
        }

        protected override void HandleClick()
        {
            onClickChannel.TryRaiseEvent(data);
        }
    }
}