using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject player;
    [Header("Keys")]
    public GameObject firstKey;
    public GameObject secondKey;
    public GameObject thirdKey;
    public GameObject lastKey;
    [Header("Doors")]
    public GameObject firstDoor;
    public GameObject secondDoor;
    public GameObject thirdDoor;
    public GameObject lastDoor;
    public GameObject currentDoor;

    public void OnCollisionEnter(Collision key)
    {
       if(key.gameObject.tag == "Key" )
        {
            key.gameObject.SetActive(false);
            currentDoor.SetActive(true);

            if(currentDoor == firstDoor)
            {
                currentDoor = secondDoor;
            }
            if (currentDoor == secondDoor)
            {
                currentDoor = thirdDoor;
            }
            if (currentDoor == thirdDoor)
            {
                currentDoor = lastDoor;
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        currentDoor = firstDoor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
