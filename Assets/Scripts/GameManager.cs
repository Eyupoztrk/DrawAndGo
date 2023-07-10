using System;
using System.Collections;
using System.Collections.Generic;
using PathCreation;
using UnityEngine;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public List<Vector3> PlayerPositions;
    public List<Vector3> enemyPositions;
    
    public List<GameObject> players;
    public List<GameObject> enemies;
    
    public GameObject player;
    public GameObject enemy;
    
    public float waitSec;
    public float forceAmount;

    public List<PathCreator> paths;


    public void SetPlayerPos(Vector3 pos)
    {
        PlayerPositions.Add(pos);
    }
    
    public void SetEnemyPos(Vector3 pos)
    {
        enemyPositions.Add(pos);
    }


    public void SetPlayer()
    {
        StartCoroutine(WaitAndInstantiateForPlayer());
    }
    
    public void SetEnemy()
    {
        StartCoroutine(WaitAndInstantiateEnemy());
    }

    IEnumerator WaitAndInstantiateForPlayer()
    {
        foreach (var item in PlayerPositions)
        {
            GameObject copyPlayer = Instantiate(player, item, Quaternion.identity);
            players.Add(copyPlayer);
            yield return new WaitForSeconds(waitSec);
        }

        foreach (var item in players)
        {
            item.GetComponent<Player>().canMove = true;
        }
        
    } 
    
    IEnumerator WaitAndInstantiateEnemy()
    {
        foreach (var item in enemyPositions)
        {
            GameObject copyPlayer = Instantiate(enemy, item, Quaternion.identity);
            enemies.Add(copyPlayer);
            yield return new WaitForSeconds(waitSec);
        }

        foreach (var item in enemies)
        {
            if(item.GetComponent<Player>()!= null)
              item.GetComponent<Player>().canMove = true;
        }
        
    }
}
