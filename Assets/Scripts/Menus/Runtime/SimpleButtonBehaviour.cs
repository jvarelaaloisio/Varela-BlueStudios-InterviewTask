using Events.Runtime.Channels;
using Events.Runtime.Channels.Helpers;
using UnityEngine;

namespace Menus.Runtime
{
    public class SimpleButtonBehaviour : ButtonBehaviour
    {
        /// <summary>
        /// Setups this button behaviour. Meant for runtime instancing
        /// </summary>
        /// <param name="title"></param>
        /// <param name="clickChannel"></param>
        public virtual void Setup(string title, VoidChannelSo clickChannel)
        {
            SetTitle(title);
            onClickChannel = clickChannel;
        }

        protected override void HandleClick()
        {
            onClickChannel.TryRaiseEvent();
        }
    }
}