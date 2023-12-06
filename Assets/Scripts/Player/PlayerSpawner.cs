using UnityEngine;
using UnityEngine.SceneManagement;

namespace Player
{
    /// <summary>
    /// Spawns a character and it's corresponding input to be able to control it
    /// </summary>
    public class PlayerSpawner : MonoBehaviour
    {
        [SerializeField] private PlayerInputReader inputReaderPrefab;
        [SerializeField] private Characters.Control.CharacterController characterPrefab;

        private void Start()
        {
            var inputReader = Instantiate(inputReaderPrefab, Vector3.zero, Quaternion.identity);
            SceneManager.MoveGameObjectToScene(inputReader.gameObject, gameObject.scene);
            var characterController = Instantiate(characterPrefab, transform.position, transform.rotation);
            SceneManager.MoveGameObjectToScene(characterController.gameObject, gameObject.scene);
            inputReader.CharacterController = characterController;
        }
    }
}
