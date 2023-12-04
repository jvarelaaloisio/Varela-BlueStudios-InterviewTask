using System.Collections;
using EventChannels.Runtime.Additions.Ids;
using Events.Runtime.Channels;
using Events.Runtime.Channels.Helpers;
using UnityEngine;

namespace Management.Runtime
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private SceneNavigator sceneNavigator;
        [SerializeField] private Id mainMenu;
        
        [Header("Channels listened")]
        [SerializeField] private VoidChannelSo quitChannel;
        [SerializeField] private IdChannelSo goToScene;

        private IEnumerator Start()
        {
            if (sceneNavigator == null)
            {
                Debug.LogError($"{name}: {nameof(sceneNavigator)} is null!");
                yield break;
            }

            yield return sceneNavigator.NavigateTo(mainMenu, true);
        }

        private void OnEnable()
        {
            if (!sceneNavigator)
                return;
            goToScene.TrySubscribe(GoToScene);
            quitChannel.TrySubscribe(QuitGame);
        }

        private void GoToScene(Id id)
        {
            if (sceneNavigator && id)
                StartCoroutine(sceneNavigator.NavigateTo(id, false));
        }

        private static void QuitGame()
        {
#if UNITY_EDITOR
            if (Application.isPlaying)
            {
                UnityEditor.EditorApplication.isPlaying = false;
            }
#endif
            Application.Quit();
        }
    }
}