using System;
using UnityEngine;

namespace Buttons.Runtime
{
    [Serializable]
    public abstract class ButtonConfig : ScriptableObject
    {
        [field: SerializeField] public string Content { get; set; }
        public abstract ButtonBehaviour Instantiate(Vector3 position, Quaternion rotation, Transform parent);
    }
}