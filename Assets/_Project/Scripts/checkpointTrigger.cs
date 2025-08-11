using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class checkpointTrigger : MonoBehaviour
{
   // public event EventHandler ;

    private Transform position; 

    // Start is called before the first frame update
    void Start()
    {
        Vector2 exactPosition = transform.position;
        Debug.Log(exactPosition);
      //  GetComponent Player;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player exited the trigger!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
