using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputReader : MonoBehaviour
{
    [field: SerializeField] public Characters.Control.CharacterController CharacterController { get; private set; }
    [Header("Input Actions")]
    [SerializeField] private InputActionAsset inputActionAsset;
    [SerializeField] private string runActionName = "Run";
    
    private PlayerInput _playerInput;

    private void OnEnable()
    {
        StartCoroutine(SubscribeToInputAfterOneFrame());
    }

    private void OnDisable()
    {
        if (!inputActionAsset)
        {
            Debug.LogError($"{name} ({GetType().Name}): {nameof(inputActionAsset)} is null!");
            return;
        }
        var runAction = inputActionAsset.FindAction(runActionName);
        if (runAction != null)
        {
            runAction.performed -= HandleRunInput;
            runAction.canceled -= HandleRunInput;
        }
    }

    /// <summary>
    /// Subscribes to all read inputs after one frame, to avoid any lag-related high/wrong values.
    /// </summary>
    /// <returns></returns>
    private IEnumerator SubscribeToInputAfterOneFrame()
    {
        if (!inputActionAsset)
        {
            Debug.LogError($"{name} ({GetType().Name}): {nameof(inputActionAsset)} is null!");
            yield break;
        }

        yield return null;
        var runAction = inputActionAsset.FindAction(runActionName);
        if (runAction != null)
        {
            runAction.performed += HandleRunInput;
            runAction.canceled += HandleRunInput;
        }
    }
    
    /// <summary>
    /// Movement input
    /// </summary>
    /// <param name="obj"></param>
    private void HandleRunInput(InputAction.CallbackContext obj)
    {
        var inputValue = obj.ReadValue<Vector2>();
        CharacterController.SetRunDirection(inputValue);
    }
}
