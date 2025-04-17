using UnityEditor.Rendering;
using UnityEngine;

public class DoorDetector : MonoBehaviour
{

    private DoorOpener doorOpener; // Reference to the DoorOpener script
    public Keybinds keybinds; // Reference to the Keybinds script

    void Start()
    {
        doorOpener = GetComponentInParent<DoorOpener>(); // Get the DoorOpener script from the parent object
        // set keybinds to the Keybinds script in the scene
        if (keybinds == null)
        {
            keybinds = FindFirstObjectByType<Keybinds>();
            if (keybinds == null)
            {
                Debug.LogError("Keybinds script not found in the scene.");
            }
        }
    }
    void Update()
    {
        DoorCheck();
    }

    /*
    *   This method checks if the player is close enough to the door by comparing the distance between the door and the camera.
    *   If the distance is less than 2 units, it returns true; otherwise, it returns false.
    */
    private bool CloseEnough(){
            if(Vector3.Distance(transform.position, Camera.main.transform.position) < 2f){  return true;  }
        return false;
    }

    /*
    *   This method checks if the player is close enough to the door and if the doorOpener is not null.
    *   If both conditions are met, it checks for key presses to toggle the door or change its lock state.
    *   Key E toggles the door, and key L changes the lock state.
    */
    private void DoorCheck(){
        if(CloseEnough() && LookingAtDoor() && doorOpener != null && keybinds != null){
            if (Input.GetKeyDown(keybinds.useKey)){ 
                doorOpener.ToggleDoor();
            }else if(Input.GetKeyDown(keybinds.lockKey)){
                doorOpener.ChangeLockState(); 
            } 
        }
    }

    /*
    *   This method checks if the player is looking at the door by casting a ray from the camera to the door.
    *   If the ray hits the door, it returns true; otherwise, it returns false.
    */
    private bool LookingAtDoor(){
        RaycastHit hit;
        if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit)){
            if(hit.collider.gameObject == gameObject){
                return true;
            }
        }
        return false;
    }
}
