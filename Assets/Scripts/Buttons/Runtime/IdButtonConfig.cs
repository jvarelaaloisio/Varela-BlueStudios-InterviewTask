using System;

using UnityEngine;
using Object = UnityEngine.Object;

using EventChannels.Runtime.Additions.Ids;

namespace Buttons.Runtime
{
    [CreateAssetMenu(menuName = "Models/Buttons/Id config", fileName = "IdButtonConfig", order = 0)]
    [Serializable]
    public class IdButtonConfig : ButtonConfig
    {
        [Header("Setup")]
        [SerializeField] protected IdButtonBehaviour buttonPrefab;
        [SerializeField] protected Id id;
        [field: SerializeField] public IdChannelSo OnClickChannel { get; set; }

        public override ButtonBehaviour Instantiate(Vector3 position, Quaternion rotation, Transform parent)
        {
        
            var button = Object.Instantiate(buttonPrefab, position, rotation, parent);
            button.Setup(Content, OnClickChannel, id);
            return button;
        }
    }
}