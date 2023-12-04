using System;
using Characters.Movement;
using UnityEngine;

namespace Characters.Visuals
{
    public class CharacterAnimatorController : MonoBehaviour
    {
        [Header("Setup")]
        [SerializeField] private Rigidbody2D rigidbody2D;
        [SerializeField] private Animator animator;
        
        [Header("Animator parameters")]
        [SerializeField] private string speedParameter = "speed";

        private int _speedParameterHash;

        private void Reset()
        {
            animator ??= GetComponent<Animator>();
        }

        private void Awake()
        {
            _speedParameterHash = Animator.StringToHash(speedParameter);
        }

        private void Update()
        {
            if (animator && rigidbody2D)
            {
                var speed = rigidbody2D.velocity.magnitude;
                animator.SetFloat(_speedParameterHash, speed);
            }
        }
    }
}
