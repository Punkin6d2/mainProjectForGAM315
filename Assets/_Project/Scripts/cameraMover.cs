using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class cameraMover : MonoBehaviour
{
    [SerializeField] Vector3 camLocation;
    [SerializeField] float camSize;
    
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Camera.main.transform.position = camLocation;
            Camera.main.orthographicSize = camSize;
        }
    }
}
//orthographicsize