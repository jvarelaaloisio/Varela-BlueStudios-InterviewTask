using System;

using UnityEngine;
using Object = UnityEngine.Object;

using Events.Runtime.Channels;

namespace Buttons.Runtime
{
    [CreateAssetMenu(menuName = "Models/Buttons/simple button config", fileName = "SimpleButtonConfig", order = 0)]
    [Serializable]
    public class SimpleButtonConfig : ButtonConfig
    {
        [Header("Setup")]
        [SerializeField] protected SimpleButtonBehaviour buttonPrefab;
        [field: SerializeField] public VoidChannelSo OnClickChannel { get; set; }

        public override ButtonBehaviour Instantiate(Vector3 position, Quaternion rotation, Transform parent)
        {
        
            var button = Object.Instantiate(buttonPrefab, position, rotation, parent);
            button.Setup(Content, OnClickChannel);
            return button;
        }
    }
}