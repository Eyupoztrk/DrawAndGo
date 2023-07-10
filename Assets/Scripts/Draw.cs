using System.Collections;
using System.Collections.Generic;
using System.IO;
using PathCreation;
using UnityEngine;


public class Draw : MonoBehaviour
{
    public LineRenderer _line;
     private Vector3 _previousPos;
     public float minDistance;


     void Start()
    {
        _line = GetComponent<LineRenderer>();
      
    }

    private float counter = 0;

    private void Update()
    {
        counter += Time.deltaTime;
    }

    public void DrawLine()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
           RaycastHit hit;
           
           if (Physics.Raycast(ray, out hit))
           {
               var newHit = new Vector3(hit.point.x,0,hit.point.z);
               _line.positionCount++; 
               _line.SetPosition(_line.positionCount-1,newHit);
               GameManager.instance.SetPlayerPos(hit.point);
           }
    }
}
