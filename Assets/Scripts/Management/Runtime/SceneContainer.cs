using System;
using System.Collections;

using UnityEngine;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif

using EventChannels.Runtime.Additions.Ids;

namespace Management.Runtime
{
    [Serializable]
    public class SceneContainer
    {
        [Header("Config")]
#if UNITY_EDITOR
        [SerializeField] private SceneAsset scene;
#endif
        [field: SerializeField] public string SceneName { get; set; }
        [field: SerializeField] public Id ID { get; set; }

        public bool IsLoaded { get; private set; }
        
        public void Validate()
        {
#if UNITY_EDITOR
            if (scene) SceneName = scene.name;
#endif
        }

        public IEnumerator Load()
        {
            if (!IsSceneValid(SceneName))
                yield break;

            var operation = SceneManager.LoadSceneAsync(SceneName, LoadSceneMode.Additive);
            yield return new WaitUntil(() => operation.isDone);
            IsLoaded = true;
        }

        public IEnumerator Unload()
        {
            if (!IsSceneValid(SceneName))
                yield break;

            var operation = SceneManager.UnloadSceneAsync(SceneName);
            yield return new WaitUntil(() => operation.isDone);
            IsLoaded = false;
        }

        private static bool IsSceneValid(string scenePath)
        {
            var sceneIndex = SceneUtility.GetBuildIndexByScenePath(scenePath);
            if (sceneIndex != -1)
                return true;
            Debug.LogError($"{nameof(SceneContainer)}: Wrong scene name given [{scenePath}]");
            return false;

        }
    }
}