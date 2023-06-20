using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;

namespace Coin
{
    public class InputManager : MonoBehaviour
    {
        [SerializeField] private Camera camera;
        [SerializeField] private float raycastDistance;
        private InputActions inputActions;

        private void Awake()
        {
            inputActions = new InputActions();
            EnhancedTouchSupport.Enable();
            inputActions.Controls.Pointer.performed += _ => ProcessTap();
        }

        private void OnEnable()
        {
            inputActions.Enable();
        }

        private void OnDisable()
        {
            inputActions.Disable();
        }

        private void ProcessTap()
        {
            var pointerPosition = inputActions.Controls.PointerPosition.ReadValue<Vector2>();
            if (Physics.Raycast(camera.ScreenPointToRay(pointerPosition), out var hit, raycastDistance) &&
                hit.transform.TryGetComponent<Coin>(out var coin))
            {
                coin.SetRandomColor();
            }
        }
    }
}