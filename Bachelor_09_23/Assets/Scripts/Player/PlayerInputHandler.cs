using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    public Vector2 MovementInput { get; private set; }

    [SerializeField]
    private Camera camera;
    [SerializeField]
    private LayerMask groundMask;

    public void OnMove(InputAction.CallbackContext ctx)
    {
        MovementInput = ctx.ReadValue<Vector2>();
    }

    public (bool success, Vector3 position) GetMousePosition()
    {
        var ray = camera.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out var hitINfo, Mathf.Infinity, groundMask))
        {
            return (success: true, position: hitINfo.point);
        }
        else
        {
            return (success: false, position: Vector3.zero);
        }
    }
}
