using Characters.Movement;
using UnityEngine;

namespace Characters.Control
{
    public class CharacterController : MonoBehaviour
    {
        [field: SerializeField] public Run run { get; private set; }

        private void OnValidate()
        {
            run ??= GetComponent<Run>();
        }

        /// <summary>
        /// Sets the run direction for the character
        /// </summary>
        /// <param name="value"></param>
        public void SetRunDirection(Vector2 value)
        {
            run.SetDirection(value);
        }
    }
}
