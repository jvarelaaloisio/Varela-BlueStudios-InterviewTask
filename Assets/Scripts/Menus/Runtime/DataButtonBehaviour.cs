using Events.Runtime.Channels;
using Events.Runtime.Channels.Helpers;
using UnityEngine;

namespace Menus.Runtime
{
    public abstract class DataButtonBehaviour<T> : ButtonBehaviour
    {
        [SerializeField] protected T data;
        [SerializeField] protected new ChannelSo<T> onClickChannel;
        
        /// <summary>
        /// Setups this button behaviour. Meant for runtime instancing
        /// </summary>
        /// <param name="title"></param>
        /// <param name="clickChannel"></param>
        /// <param name="clickEventData"></param>
        public virtual void Setup(string title, ChannelSo<T> clickChannel)
        {
            SetTitle(title);
            onClickChannel = clickChannel;
        }

        protected override void HandleClick()
        {
            onClickChannel.TryRaiseEvent(data);
        }
    }
}