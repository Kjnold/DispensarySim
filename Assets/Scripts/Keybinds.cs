using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Keybinds : MonoBehaviour
{
    public KeyCode pickupKey = KeyCode.F; // Key to pick up items
    public KeyCode placeKey = KeyCode.Mouse1; // Key to drop items
    public KeyCode useKey = KeyCode.E; // Key to use items
    public KeyCode lockKey = KeyCode.L; // Key to lock/unlock doors
    public KeyCode moveItemUpKey = KeyCode.Keypad8; // Key to move item up
    public KeyCode moveItemDownKey = KeyCode.Keypad5; // Key to move item down
    public KeyCode moveItemLeftKey = KeyCode.Keypad4; // Key to move item left
    public KeyCode moveItemRightKey = KeyCode.Keypad6; // Key to move item right
    public KeyCode moveItemForwardKey = KeyCode.Keypad7; // Key to move item forward
    public KeyCode moveItemBackwardKey = KeyCode.Keypad9; // Key to move item backward
    public KeyCode moveItemRotateHorizontalLeftKey = KeyCode.Keypad1; // Key to rotate item horizontally
    public KeyCode moveItemRotateHorizontalRightKey = KeyCode.Keypad3; // Key to rotate item horizontally
    public KeyCode moveItemRotateVerticleKey = KeyCode.Keypad2; // Key to rotate item vertically
    

    public KeyCode forwardKey = KeyCode.W; // Key to move forward
    public KeyCode backwardKey = KeyCode.S; // Key to move backward
    public KeyCode leftKey = KeyCode.A; // Key to move left
    public KeyCode rightKey = KeyCode.D; // Key to move right
    public KeyCode jumpKey = KeyCode.Space; // Key to jump
    public KeyCode crouchKey = KeyCode.R; // Key to crouch
    public KeyCode sprintKey = KeyCode.LeftShift; // Key to sprint


    public KeyCode cameraKey = KeyCode.F5; // Key to toggle camera mode

}
