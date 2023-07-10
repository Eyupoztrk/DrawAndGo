using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cylinder : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerControl"))
        {
            Debug.Log("kaybetti");
        }
        
        if (other.gameObject.CompareTag("EnemyControl"))
        {
            Debug.Log("kaazandı");
        }
    }
}
