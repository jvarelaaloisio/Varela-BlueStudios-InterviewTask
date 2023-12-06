using System;
using System.Collections;
using UnityEngine;

namespace Characters.Movement
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Run : MonoBehaviour
    {
        private const float DeltaTimeForceScaleCompensation = 1000;
        
        [SerializeField] private Config config = new(2000, new Vector2(10, 10));

        private Rigidbody2D _rigidbody;
        private Vector2 _scaledDirection;

        public void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void OnEnable() => StartCoroutine(Move());

        private void OnDisable() => StopCoroutine(Move());

        private IEnumerator Move()
        {
            while (enabled)
            {
                yield return new WaitForFixedUpdate();
                var force = _scaledDirection * (config.movementForce * Time.fixedDeltaTime * DeltaTimeForceScaleCompensation);
                if (force.magnitude == 0)
                    continue;
                // force.x *= config.targetVelocity.x - Mathf.Abs(_rigidbody.velocity.x);
                if (force.x > 0 && _rigidbody.velocity.x >= config.targetVelocity.x
                    || force.x < 0 && _rigidbody.velocity.x <= -config.targetVelocity.x)
                    force.x = 0;
                if (force.y > 0 && _rigidbody.velocity.y >= config.targetVelocity.y
                    || force.y < 0 && _rigidbody.velocity.y <= -config.targetVelocity.y)
                    force.y = 0;

                _rigidbody.AddForce(force, ForceMode2D.Force);
            }
        }

        public void SetDirection(Vector2 scaledDirection) => _scaledDirection = scaledDirection;
        
        [Serializable]
        public struct Config
        {
            public float movementForce;
            public Vector2 targetVelocity;

            public Config(float movementForce, Vector2 targetVelocity)
            {
                this.movementForce = movementForce;
                this.targetVelocity = targetVelocity;
            }
        }
    }
}
