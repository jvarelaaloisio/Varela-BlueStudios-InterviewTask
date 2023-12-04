using System;
using EventChannels.Runtime.Additions.Ids;
using UnityEngine;

namespace Customization.Runtime
{
    public class CustomizerDebugger : MonoBehaviour
    {
        [SerializeField] private Customizer<Sprite> customizer;

        private void Reset()
        {
            customizer = GetComponent<Customizer<Sprite>>();
        }
        
#if UNITY_EDITOR

        [SerializeField] private Id id;
        [SerializeField] private Sprite sprite;

        [ContextMenu("customize")]
        private void Customize()
        {
            customizer.Customize(id, sprite);
        }
#endif
    }
}
