using UnityEngine;

namespace Characters.Visuals
{
    public class CharacterView : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D rigidbody2D;
        
        private void Update()
        {
            if (!transform.hasChanged || !rigidbody2D)
                return;
            var yAngle = Mathf.Sign(rigidbody2D.velocity.x) < 0 ? 180 : 0;
            transform.rotation = Quaternion.Euler(0, yAngle,0);
        }
    }
}