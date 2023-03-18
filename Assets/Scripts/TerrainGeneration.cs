using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TerrainGeneration : MonoBehaviour
{
    private const int MAX_VISITED = 2;

    [SerializeField]
    private GameObject plane;
    [SerializeField]    
    private GameObject player;

    private int mapRadius = 1;
    private int planeOffset = 450;
    private Vector3 startPos = Vector3.zero;
    private int XPlayerMove => (int)(player.transform.position.x - startPos.x); // gets called every update I guess? expression-bodied property '=>'
    private int ZPlayerMove => (int)(player.transform.position.z - startPos.z);

    private int XPlayerLocation => (int)Mathf.Floor(player.transform.position.x / planeOffset) * planeOffset;
    private int ZPlayerLocation => (int)Mathf.Floor(player.transform.position.z / planeOffset) * planeOffset;

    private Hashtable tilePlane = new Hashtable();
    private Vector3 prevPos;
    private Vector3[] posStack;
    private GameObject[] mapPool;
    private int visited = 0;
    

    // Start is called before the first frame update
    private void Start()
    {
        posStack = new Vector3[MAX_VISITED];   // currently instantiated positions
        mapPool = new GameObject[MAX_VISITED];  // array that holds maps equal to MAX_VISITED

        Vector3 pos = new Vector3((0 * planeOffset + XPlayerLocation),
                        0f,
                        (0 * planeOffset + ZPlayerLocation));
        tilePlane.Add(pos, instantiateTile(pos));
    }
    private void Update()
    {
        /* if (hasPlayerMoved())
         {
             for (int x = -mapRadius; x < mapRadius; x++)
             {
                 for (int z = -mapRadius; z < mapRadius; z++)
                 {
                     Vector3 pos = new Vector3((x * planeOffset + XPlayerLocation),
                         0f,
                         (z * planeOffset + ZPlayerLocation));
                     if (!tilePlane.Contains(pos))
                     {
                         GameObject _plane = Instantiate(plane, pos, Quaternion.identity);
                         _plane.SetActive(true);
                         tilePlane.Add(pos, _plane);
                     }
                 }
             }
         }*/

        /*if (hasPlayerMoved())
        {
            Vector3 pos = new Vector3((0 * planeOffset + XPlayerLocation),
                        0f,
                        (0 * planeOffset + ZPlayerLocation));
            Debug.Log("Current pos: "+pos);
            if (!tilePlane.Contains(pos))   // prevents instantiating map if in same pos currently
            {
                Debug.Log("Current pos has not been visited!");
                instantiateTile(pos);
            }
            else
            {
                // Check if pos is same as prevPos
                if (pos != prevPos)
                {
                    Debug.Log("position has changed!");
                    if (Array.IndexOf(posStack, pos) == -1) // if not instantiated maps pool
                    {
                        Debug.Log("Current pos has been visited but not instantiated");
                        instantiateTile(pos);
                    }
                    else
                    {
                        Debug.Log("Current pos has been visited and instantiated"); // do nothing
                    }
                }                
            }
        }*/

        Vector3 pos = new Vector3((0 * planeOffset + XPlayerLocation),
                        0f,
                        (0 * planeOffset + ZPlayerLocation));
        Debug.Log("Current pos: " + pos);
        if (!tilePlane.Contains(pos))   // prevents instantiating map if in same pos currently
        {
            Debug.Log("Current pos has not been visited!");
            tilePlane.Add(pos, instantiateTile(pos));
        }
        else
        {
            // Check if pos is same as prevPos
            if (pos != prevPos)
            {
                Debug.Log("position has changed!");
                if (Array.IndexOf(posStack, pos) == -1) // if not instantiated maps pool
                {
                    Debug.Log("Current pos has been visited but not instantiated");
                    instantiateTile(pos);
                }
                else
                {
                    Debug.Log("Current pos has been visited and instantiated"); // do nothing
                }
            }
        }
    }

    bool hasPlayerMoved()
    {
        if(Mathf.Abs(XPlayerMove) >= planeOffset || Mathf.Abs(ZPlayerMove) >= planeOffset)
        {
            return true;
        }
        return false;
    }

    GameObject instantiateTile(Vector3 pos)
    {
        GameObject _plane = Instantiate(plane, pos, Quaternion.identity);
        _plane.SetActive(true);
        prevPos = pos;
        if(visited < MAX_VISITED)
        {
            Debug.Log("Adding pos " + pos);
            posStack[visited] = pos;
            mapPool[visited] = _plane;
            visited++;
        }
        //if (visited >= MAX_VISITED)
        else
        {
            Debug.Log("Shifting pos " + pos);
            Array.Copy(posStack, 1, posStack, 0, posStack.Length - 1);
            posStack[MAX_VISITED - 1] = pos;
            Destroy(mapPool[0]);
            Array.Copy(mapPool, 1, mapPool, 0, mapPool.Length - 1);
            mapPool[MAX_VISITED - 1] = _plane;
        }
        return _plane;
    }

}
