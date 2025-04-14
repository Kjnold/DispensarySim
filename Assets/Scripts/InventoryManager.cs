using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    private bool holdingItem = false; // Flag to check if the item is being held
    private GameObject holdingItemObject; // Reference to the currently held item
    private Transform Cam; // Reference to the main camera's transform
    private Keybinds keybinds; // Reference to the Keybinds script
    private bool canBeDropped = true; // Flag to check if the item can be dropped

    void Start()
    {
        Cam = Camera.main.transform; // Get the main camera's transform
        keybinds = FindFirstObjectByType<Keybinds>(); // Find the Keybinds script in the scene
    }

    void Update()
    {
        if(holdingItem){
            holdingItemObject.GetComponent<Rigidbody>().isKinematic = true; // Set the rigidbody to kinematic to prevent physics interactions

            switch (true){
                case var _ when Input.GetKey(keybinds.moveItemUpKey): // Move item up
                    holdingItemObject.transform.position += Cam.up * Time.deltaTime * 0.5f;
                    break;
                case var _ when Input.GetKey(keybinds.moveItemDownKey): // Move item down
                    holdingItemObject.transform.position -= Cam.up * Time.deltaTime * 0.5f;
                    break;
                case var _ when Input.GetKey(keybinds.moveItemLeftKey): // Move item left
                    holdingItemObject.transform.position -= Cam.right * Time.deltaTime * 0.5f;
                    break;
                case var _ when Input.GetKey(keybinds.moveItemRightKey): // Move item right
                    holdingItemObject.transform.position += Cam.right * Time.deltaTime * 0.5f;
                    break;
                case var _ when Input.GetKey(keybinds.moveItemForwardKey): // Move item forward
                    holdingItemObject.transform.position += Cam.forward * Time.deltaTime * 0.5f;
                    break;
                case var _ when Input.GetKey(keybinds.moveItemBackwardKey): // Move item backward
                    holdingItemObject.transform.position -= Cam.forward * Time.deltaTime * 0.5f;
                    break;
                case var _ when Input.GetKey(keybinds.moveItemRotateHorizontalLeftKey): // Rotate item left
                    holdingItemObject.transform.Rotate(Vector3.up, -1f);
                    break;
                case var _ when Input.GetKey(keybinds.moveItemRotateHorizontalRightKey): // Rotate item right
                    holdingItemObject.transform.Rotate(Vector3.up, 1f);
                    break;
                case var _ when Input.GetKey(keybinds.moveItemRotateVerticleKey): // Rotate item vertically
                    holdingItemObject.transform.Rotate(Vector3.right, 1f);
                    break;
                case var _ when Input.GetKey(keybinds.placeKey): // Place item
                    if(canBeDropped) PlaceItem();
                    break;
            }

        }
    }

    private void PlaceItem(){
        holdingItemObject.GetComponent<Rigidbody>().isKinematic = false; // Set the rigidbody to non-kinematic to allow physics interactions
        holdingItemObject.transform.parent = null; // Detach the item from its parent
        holdingItem = false; // Reset the holding item flag
        holdingItemObject = null; // Clear the reference to the held item
    }

    public void CanBeDropped(bool canDrop){ canBeDropped = canDrop; } // Method to set the drop state of the item
    public void PickupItem(GameObject item)
    {
        if (Input.GetKeyDown(keybinds.pickupKey) && !holdingItem)
        {
            holdingItem = true; // Set the flag to true when picking up an item
            holdingItemObject = item; // Set the held item to the picked up item
            item.transform.parent = gameObject.transform; // Set the parent to the object this script is attached to
            Debug.Log("Picked up: " + item.name);
        }
    }

}
    /*
    * a non function item pickup system
    * Attempt Two
    *
    private static bool isPickedUp = false; // Flag to check if the item is picked up
    private static GameObject holdingItem; // Reference to the currently held item
    private bool isColliding = false; // Flag to check if the item is colliding with another object
    private Transform Cam = Camera.main.transform; // Reference to the main camera's transform
    void Update()
    {
        if(isPickedUp){
            // Update the position of the held item to follow the player
            if(!isColliding){
                holdingItem.transform.position = Cam.position + Cam.forward * 2; // Adjust the position in front of the camera
                holdingItem.transform.rotation = Cam.rotation; // Keep the rotation aligned with the camera
            }
        }
    }

    void OnCollisionEnter(Collision collision){
        isColliding = true; // Set the flag to true when colliding with another object
        if(isPickedUp){
            holdingItem.transform.position = collision.transform.position; // Set the position to the collision point
            holdingItem.transform.position += collision.transform.forward * 2; // Adjust the position in front of the collided object
            isColliding = false; // Reset the flag after setting the position
        }
    }


    public static void pickupItem(GameObject item){
        isPickedUp = true; // Set the flag to true after picking up the item
        holdingItem = item; // Call the holdingItem method to update the item's state
        Debug.Log("Picked up: " + item.name);
    }

    public static void dropItem(GameObject item){
        item.transform.parent = null; // Detach the item from its parent
        isPickedUp = false; // Set the flag to false after dropping the item
        holdingItem = null; // Clear the reference to the held item
        Debug.Log("Dropped: " + item.name);
    }
    *
    */











    /*
    * this is a not working hotbar setup
    * Attempt One
    *
    public GameObject[] HotbarUI = new GameObject[10];
    private GameObject[] HotbarSlots = new GameObject[10];
    private int[] HotbarQuantity = new int[10];

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject[] GetHotbarSlots(){  return HotbarSlots;  }
    public int[] GetHotbarQuantity(){  return HotbarQuantity;  }
    public void SetHotbarSlots(GameObject[] slots){  HotbarSlots = slots;  }
    public void SetHotbarQuantity(int[] quantity){  HotbarQuantity = quantity;  }

    public void SendImage(Sprite image, int index){
        if (index >= 0 && index < HotbarUI.Length){
            HotbarUI[index].GetComponent<Image>().sprite = image;
        }
    }
    *
    */

