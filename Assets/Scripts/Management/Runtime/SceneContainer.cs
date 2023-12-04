using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Management.Runtime
{
    [Serializable]
    public class SceneContainer
    {
#if UNITY_EDITOR
        [SerializeField] private SceneAsset scene;
#endif
        [SerializeField] private string sceneName;

        public void OnValidate()
        {
#if UNITY_EDITOR
            if (scene) sceneName = scene.name;
#endif
        }

        public IEnumerator Load()
        {
            var sceneIndex = SceneUtility.GetBuildIndexByScenePath(sceneName);
            if (sceneIndex == -1)
            {
                Debug.LogError($"{nameof(SceneContainer)}: Wrong scene name given [{sceneName}]");
                yield break;
            }

            var operation = SceneManager.LoadSceneAsync(sceneName);
            yield return new WaitUntil(() => operation.isDone);
        }
    }
}