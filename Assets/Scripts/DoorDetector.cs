using UnityEngine;

public class DoorDetector : MonoBehaviour
{

    private DoorOpener doorOpener;
    void Start()
    {
        doorOpener = GetComponentInParent<DoorOpener>();
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
        if(Vector3.Distance(transform.position, Camera.main.transform.position) < 2f){
            return true;
        }
        return false;
    }

    /*
    *   This method checks if the player is close enough to the door and if the doorOpener is not null.
    *   If both conditions are met, it checks for key presses to toggle the door or change its lock state.
    *   Key E toggles the door, and key L changes the lock state.
    */
    private void DoorCheck(){
        if(CloseEnough() && LookingAtDoor() &&doorOpener != null){
            if (Input.GetKeyDown(KeyCode.E)){   doorOpener.ToggleDoor();   }
            else if(Input.GetKeyDown(KeyCode.L)){   doorOpener.ChangeLockState();   }
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
