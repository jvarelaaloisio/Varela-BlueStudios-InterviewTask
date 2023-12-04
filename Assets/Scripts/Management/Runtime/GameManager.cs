using UnityEngine;

namespace Management.Runtime
{
    public class GameManager : MonoBehaviour
    {
        [Header("Scenes")]
        [SerializeField] private SceneContainer menu = new();
        [SerializeField] private SceneContainer world = new();
        [SerializeField] private SceneContainer shop = new();

        private void OnValidate()
        {
            menu.OnValidate();
            world.OnValidate();
            shop.OnValidate();
        }
    }
}