using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private static InputManager _instance;

    public static InputManager Instance { get { return _instance; } }

    private PlayerControls playerControls;

    private bool b_LockCamera = false;
    private bool b_LockControl = false;
    private void Awake()
    {
        if(_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }

        playerControls = new PlayerControls();
        Cursor.visible = false;
    }
    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    public Vector2 GetPlayerMovement()
    {
        if(b_LockControl)
        {
            return Vector2.zero;
        }
        return playerControls.Player.Movement.ReadValue<Vector2>();
    }

    public Vector2 GetMouseDelta()
    {
        if(b_LockCamera)
        {
            return Vector2.zero;
        }
        return playerControls.Player.Look.ReadValue<Vector2>();
    }

    public bool PlayerJumpedThisFrame()
    {
        if(b_LockControl)
        {
            return false;
        }
        return playerControls.Player.Jump.triggered;
    }

    public bool PlayerInteract()
    {
        if(b_LockControl)
        {
            return false;
        }
        return playerControls.Player.Interact.WasReleasedThisFrame();
    }

    public void LockControl(bool lockControl)
    {
        if (lockControl)
        {
            Cursor.visible = true;
            b_LockCamera = lockControl;
            b_LockControl = lockControl;
            Debug.Log("Camera Locked.");
        }
        if (!lockControl)
        {
            Cursor.visible = false;
            b_LockCamera = lockControl;
            b_LockControl = lockControl;
            Debug.Log("Camera Unlocked.");
        }
    }

    public void ForceLockControl()
    {
        Cursor.visible = true;
        b_LockCamera = true;
        b_LockControl = true;
        Debug.Log("Camera Force Locked.");
    }

    public void ForceUnlockControl()
    {
        Cursor.visible = false;
        b_LockCamera = false;
        b_LockControl = false;
        Debug.Log("Camera Force Unlocked.");
    }
    public bool isCamLocked()
    {
        return b_LockCamera;
    }

    public bool isControlLocked()
    {
        return b_LockControl;
    }
}
