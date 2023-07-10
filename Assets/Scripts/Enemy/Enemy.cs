using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public bool canMove = false;

    private void Start()
    {
        transform.eulerAngles = new Vector3(0, 180, 0);
    }

    void Update()
    {
        if(canMove)
            transform.Translate(transform.forward *speed *Time.deltaTime);
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(2f);
        canMove = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obj"))
        {
            GetForceToObject(collision.gameObject);
            Destroy(this.gameObject);
        }
    }

    public void GetForceToObject(GameObject obj)
    {
        obj.GetComponent<Rigidbody>().AddForce(-transform.forward *GameManager.instance.forceAmount*Time.deltaTime);
    }
}
