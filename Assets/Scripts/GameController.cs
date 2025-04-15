using UnityEngine;

public class GameController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject playerPrefab; // Reference to the player prefab
    void Start()
    {
        Instantiate(playerPrefab, new Vector3(2, 2, 10), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
