using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenMemory : MonoBehaviour
{
    public GameObject memory;
    public bool playerInSight;


    // Start is called before the first frame update
    void Start()
    {
        memory.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerInSight)
        {
            Debug.Log("button");
            memory.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("Triggered");
            playerInSight = true;
         
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("Triggered");
            playerInSight = false;
        }
    }

    public void CloseMemory()
    {
        memory.SetActive(false);
    }

}

