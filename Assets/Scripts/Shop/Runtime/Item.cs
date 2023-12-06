using UnityEngine;

namespace Shop.Runtime
{
    [CreateAssetMenu(menuName = "Models/Item", fileName = "Item", order = 0)]
    public class Item : ScriptableObject
    {
        [field: SerializeField] public Sprite Sprite { get; private set; }
    }
}