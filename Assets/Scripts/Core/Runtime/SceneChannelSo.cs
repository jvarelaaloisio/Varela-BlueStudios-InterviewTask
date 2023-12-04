using Events.Runtime.Channels;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core.Runtime
{
    [CreateAssetMenu(menuName = "Event Channels/Data Channels/Scene", fileName = "SceneDataChannel")]
    public class SceneChannelSo : ChannelSo<Scene> { }
}
