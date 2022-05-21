using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Consumable : MonoBehaviour
{

    private void Reset()
    {
        GetComponent<CircleCollider2D>().isTrigger = true;       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Debug.Log($"{name} Triggered");
        }
    }


}
