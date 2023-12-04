using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;

using Events.Runtime.Channels.Helpers;
using EventChannels.Runtime.Additions.Ids;

namespace Management.Runtime
{
    public class SceneNavigator : MonoBehaviour
    {
        [Header("Scenes")]
        [SerializeField] private SceneContainer[] scenes = {};

        [SerializeField] private IdChannelSo sceneNavigationChannel;
        
        private readonly List<SceneContainer> _volatileScenes = new();
        private readonly List<SceneContainer> _permanentScenes = new();
        private void OnValidate()
        {
            foreach (var scene in scenes)
            {
                scene.Validate();
            }
        }

        public IEnumerator NavigateTo(Id sceneId, bool isPermanent)
        {
            var scene = scenes.FirstOrDefault(sc => sc.ID == sceneId);
            if (scene == null)
            {
                Debug.LogError($"{name}: Scene ID [{sceneId}] not found!", this);
                yield break;
            }

            var sceneWasAlreadyLoaded = scene.IsLoaded;
            if (!sceneWasAlreadyLoaded)
                yield return scene.Load();

            foreach (var sc in _volatileScenes.Where(sc => sc.ID != scene.ID))
            {
                yield return sc.Unload();
            }
            _volatileScenes.Clear();

            if (!sceneWasAlreadyLoaded)
            {
                if (isPermanent)
                    _permanentScenes.Add(scene);
                else
                    _volatileScenes.Add(scene);
            }
            
            sceneNavigationChannel.TryRaiseEvent(sceneId);
        }

        public void MakePermanent(Id sceneId)
        {
            var scene = _volatileScenes.FirstOrDefault(sc => sc.ID == sceneId);
            if (scene == null || _permanentScenes.Contains(scene))
                return;
            _permanentScenes.Add(scene);
            _volatileScenes.Remove(scene);
        }
    }
}
