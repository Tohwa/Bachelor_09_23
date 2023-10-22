using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class PlayerInputHandler : MonoBehaviour
{
    public Vector2 MovementInput { get; private set; }

    [SerializeField]
    private Player player;

    public void OnMove(InputAction.CallbackContext ctx)
    {
        MovementInput = ctx.ReadValue<Vector2>();
    }

    public void ShootBullet(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            player.fire = true;
        }
        else if (ctx.canceled)
        {
            player.fire = false;
        }
    }
}
