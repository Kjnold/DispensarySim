using System.Collections;
using UnityEngine;

public class DoorOpener : MonoBehaviour
{

    private bool isLocked = false;
    private int isOpen = 1;

    public void ToggleDoor()
    {
        if (!isLocked)
        {
            StartCoroutine(RotateDoorWithDelay());
        }
        else
        {
            Debug.Log("Door is locked!");
        }
    }

    private IEnumerator RotateDoorWithDelay()
    {
        int steps = 90; // Total degrees to rotate
        float delay = 0.01f; // Delay between each step (in seconds)

        for (int i = 0; i < steps; i++)
        {
            transform.Rotate(0, isOpen, 0); // Rotate 1 degree per step
            yield return new WaitForSeconds(delay); // Wait for the specified delay
        }

        isOpen *= -1; // Toggle the open state
        Debug.Log("Door toggled with delay!");
    }
    public void ChangeLockState(){
        // Logic to lock the door
        isLocked = !isLocked;
        Debug.Log("Door locked! (parent script)");
    }
}
