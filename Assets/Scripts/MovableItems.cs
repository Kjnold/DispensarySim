using System;
using Unity.VisualScripting;
using UnityEngine;

public class MovableItems : MonoBehaviour
{

    private InventoryManager inventoryManager; // Reference to the InventoryManager script

    void Start()
    {
        inventoryManager = FindFirstObjectByType<InventoryManager>(); // Find the InventoryManager script in the scene
    }

    void Update()
    {
        if(Vector3.Distance(transform.position, Camera.main.transform.position) < 3f)
            if(LookingAtItem()){  inventoryManager.PickupItem(gameObject);  }
    }

    private bool LookingAtItem(){
        RaycastHit hit;
        if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit)){
            if(hit.collider.gameObject == gameObject){
                return true; // Return true if the ray hits the item
            }
        }
        return false; // Return false if the ray does not hit the item
    }
}
    /*
    * a non function item pickup system
    * Attempt Two
    *
    private bool isPickedUp = false; // Flag to check if the item is picked up

    void Update(){
        if(pickupState() && !isPickedUp){
            InventoryManager.pickupItem(gameObject); // Call the pickupItem method in InventoryManager
            // gameObject.SetActive(false); // Deactivate the item after picking it up
            isPickedUp = true; // Set the flag to true after picking up the item
        }else if(pickupState() && isPickedUp){
            InventoryManager.dropItem(gameObject); // Call the dropItem method in InventoryManager
            // gameObject.SetActive(true); // Reactivate the item after dropping it
            isPickedUp = false; // Set the flag to false after dropping the item
        }
    }

    private bool pickupState(){
        if(Vector3.Distance(transform.position, Camera.main.transform.position) < 5f){
            if(Input.GetKeyDown(KeyCode.F) && LookingAtDoor()){ return true; }
        }
        return false; // Return false if the item is not picked up
    }

    private bool LookingAtDoor(){
        RaycastHit hit;
        if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit)){
            if(hit.collider.gameObject == gameObject){
                return true;
            }
        }
        return false;
    }
    *
    */


    /*
    * this is a not working hotbar setup
    * Attempt One
    *
    public InventoryManager InventoryManager; // Reference to the InventoryManager script
    public Sprite itemImage; // The image to display in the hotbar
    private GameObject[] HotbarSlots;
    private int[] HotbarQuantity;

    private void Start()
    {
        HotbarSlots = InventoryManager.GetHotbarSlots();
        HotbarQuantity = InventoryManager.GetHotbarQuantity();
    }
    void Update()
    {
        PickupState();
    }

    private void UpdateHotbar(){
        HotbarSlots = InventoryManager.GetHotbarSlots();
        HotbarQuantity = InventoryManager.GetHotbarQuantity();
    }

    private void PickupState(){
        if(Vector3.Distance(transform.position, Camera.main.transform.position) < 3f){
            if (Input.GetKeyDown(KeyCode.E)){
                UpdateHotbar();
                for(int i = 0; i < HotbarSlots.Length; i++){
                    if(HotbarSlots[i] == gameObject && HotbarQuantity[i] < 69){
                        HotbarQuantity[i]++;
                        InventoryManager.SetHotbarQuantity(HotbarQuantity);
                        gameObject.SetActive(false);
                    }
                }
                for(int i = 0; i < HotbarSlots.Length; i++){
                    if (HotbarSlots[i] == null && gameObject.activeSelf){
                        HotbarSlots[i] = gameObject;
                        HotbarQuantity[i] = 1;
                        InventoryManager.SetHotbarSlots(HotbarSlots);
                        InventoryManager.SetHotbarQuantity(HotbarQuantity);
                        InventoryManager.SendImage(itemImage, i);
                        gameObject.SetActive(false);
                    }
                }
            }
        }
    }
    *
    */

