using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class O_ReviewCam : MonoBehaviour
{
    public O_CustomImageEffect customImageEffect;
    public float speed;
    public Material[] mats;
    private int currIndx = 0;

    private void Start()
    {
        ActivateNewMat(0);
    }

    private void Update()
    {
        transform.Rotate(Vector3.up * speed * Time.deltaTime);
    
        if(Input.GetKeyDown(KeyCode.LeftArrow)){
            ActivateNewMat(currIndx - 1);
        }
        if(Input.GetKeyDown(KeyCode.RightArrow)){
            ActivateNewMat(currIndx + 1);
        }
    }

    private void ActivateNewMat(int newIndx){
        if(newIndx < 0 || newIndx >= mats.Length)
            return;
        customImageEffect.imageEffect = mats[newIndx];
        currIndx = newIndx;
    }
}
