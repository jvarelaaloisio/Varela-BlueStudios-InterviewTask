using Customization.Runtime;
using UnityEngine;

namespace Customization
{
    public class SpriteCustomizer : Customizer<Sprite>
    {
        [SerializeField] private SpriteCustomizable[] parts;

        private void Awake()
        {
            Init(parts);
        }
#if UNITY_EDITOR
        [ContextMenu("Search parts in children")]
        private void SearchPartsInChildren()
        {
            parts = transform.GetComponentsInChildren<SpriteCustomizable>();
        }
#endif
    }
}