using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGeneration : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyObject;
    [SerializeField]
    private float xPos;
    [SerializeField]
    private float zPos;
    [SerializeField]
    private int enemyCount;
    [SerializeField]
    private float timer = 0.5f;
    [SerializeField]
    private int minXRange = 10;
    [SerializeField]
    private int maxXRange = 30;
    [SerializeField]
    private int minZRange = 10;
    [SerializeField]
    private int maxZRange = 30;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemySpawn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator EnemySpawn()
    {
        while(enemyCount < 15)
        {
            xPos = Mathf.Round(Random.Range(minXRange, maxXRange)) + GameObject.Find("Player").transform.position.x;
            zPos = Mathf.Round(Random.Range(minZRange, maxXRange)) + GameObject.Find("Player").transform.position.z;
            Instantiate(enemyObject, new Vector3(xPos, 1, zPos), Quaternion.identity); 
            yield return new WaitForSeconds(timer);
            enemyCount += 1;
        }
    }

}

class Enemy{

}
