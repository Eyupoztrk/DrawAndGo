using System.Collections;
using System.Collections.Generic;
using System.IO;
using PathCreation;
using UnityEngine;

public class EnemyDraw : MonoBehaviour
{
    public PathCreator _creator;
    public LineRenderer _line;
    private Vector3 _previousPos;
    public float minDistance;
    public float drawWaitSec;

    public float drawFrequency;

    void Start()
    {
        _line = GetComponent<LineRenderer>();
        _line.positionCount = 0;
        StartCoroutine(draw());
    }

    public void SetPath()
    {
        var paths = GameManager.instance.paths;
        int random = Random.Range(0, paths.Count);
        _creator = paths[random];
    }
    
    
    public IEnumerator DrawLine()
    {
        SetPath();
        for (int i = 0; i < _creator.path.length; i++)
        {
            var point = _creator.path.GetPointAtDistance(i);
            _line.positionCount++;
            _line.SetPosition(_line.positionCount-1,point);
            GameManager.instance.SetEnemyPos(point);
            yield return new WaitForSeconds(drawWaitSec);
        }
        GameManager.instance.enemies.Clear();
        GameManager.instance.SetEnemy();
        
    }

    IEnumerator draw()
    {
        while (true)
        {
           StartCoroutine(DrawLine());
            yield return new WaitForSeconds(drawFrequency);
            GameManager.instance.enemyPositions.Clear();
            _line.positionCount = 0;
            
        }
        
        
      
    }
}
