using System;
using System.Linq;

using UnityEngine;

using Events.Runtime.Channels.Helpers;
using EventChannels.Runtime.Additions.Ids;

namespace Menus.Runtime
{
    public class MenuNavigator : MonoBehaviour
    {
        [Header("Channels listened")]
        [SerializeField] private IdChannelSo sceneLoadedChannel;

        [SerializeField] private SceneMenuPair[] menuPairs;

        [SerializeField] private SceneMenuPair lastMenuPair;

        private void OnEnable()
        {
            sceneLoadedChannel.TrySubscribe(HandleSceneLoaded);
            HandleSceneLoaded(lastMenuPair.SceneId);
        }
        private void OnDisable()
        {
            sceneLoadedChannel.TryUnsubscribe(HandleSceneLoaded);
        }

        private void HandleSceneLoaded(Id sceneId)
        {
            var pair = menuPairs.FirstOrDefault(pair => pair.SceneId == sceneId);

            if (pair == null)
                Debug.LogWarning($"{name}: No menu found for scene");

            lastMenuPair?.Menu.SetActive(false);
            
            pair?.Menu.SetActive(true);

            lastMenuPair = pair;
        }
        
        [Serializable]
        private class SceneMenuPair
        {
            [field: SerializeField] public Id SceneId { get; private set; }
            [field: SerializeField] public GameObject Menu { get; private set; }
        }
    }
}
