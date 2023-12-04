using System.Collections.Generic;
using System.Linq;

using UnityEngine;

using EventChannels.Runtime.Additions.Ids;

namespace Customization
{
    public abstract class Customizer<T> : MonoBehaviour
    {
        private Dictionary<Id, ICustomizable<T>> _customizablesById;

        /// <summary>
        /// Sets the value on the customizable based on the given Id.
        /// </summary>
        /// <param name="id">The <see cref="Id"/> to filter through the dictionary with</param>
        /// <param name="newValue">The value to set the <see cref="Customization.ICustomizable"/> to</param>
        public void Customize(Id id, T newValue)
        {
            if (_customizablesById.TryGetValue(id, out var customizable))
                customizable.Value = newValue;
            else
                Debug.LogError($"{name}: Couldn't find customizable with id [{id}]");
        }
        
        /// <summary>
        /// Initializes the internal dictionary based no the given array
        /// </summary>
        /// <param name="customizables"></param>
        /// <returns>the new dictionary</returns>
        [ContextMenu("Initialize")]
        protected Dictionary<Id, ICustomizable<T>> Init(IEnumerable<ICustomizable<T>> customizables)
        {
            if (!customizables.Any())
                Debug.LogWarning($"{name}: No customizables given! This component won't be able to customize anything");
            _customizablesById = customizables.Where(customizable => customizable.ID != null).ToDictionary(customizable => customizable.ID);
            return _customizablesById;
        }
    }
}