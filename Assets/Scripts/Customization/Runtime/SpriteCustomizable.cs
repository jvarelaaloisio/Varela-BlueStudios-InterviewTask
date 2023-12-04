using UnityEngine;

using EventChannels.Runtime.Additions.Ids;

namespace Customization.Runtime
{
    public class SpriteCustomizable : MonoBehaviour, ICustomizable<Sprite>
    {
        [field: SerializeField] public Id ID { get; set; }
        [SerializeField] private SpriteRenderer spriteRenderer;

        public Sprite Value
        {
            get => spriteRenderer ? spriteRenderer.sprite : null;
            set
            {
                if (spriteRenderer == null)
                {
                    Debug.LogError($"{name}: {nameof(spriteRenderer)} is null!");
                    return;
                }

                spriteRenderer.sprite = value;
            }
        }

        private void Reset()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }
    }
}