using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGeneration : MonoBehaviour
{
    // =================== Serializable Fields =================================================================

    [SerializeField]
    private GameObject plane, player;
    [SerializeField]
    private int tileSize = 50, mapRowRadius = 1, mapColumnRadius = 1, planeOffset = 50;

    // =========================================================================================================
    private int gridCount = 9;

    private Vector3 startPos = Vector3.zero;
    private int XPlayerMove => (int)(player.transform.position.x - startPos.x); // gets called every update I guess? expression-bodied property '=>'
    private int ZPlayerMove => (int)(player.transform.position.z - startPos.z);
    private int XPlayerLocation => (int)Mathf.Floor(player.transform.position.x / planeOffset) * planeOffset;
    private int ZPlayerLocation => (int)Mathf.Floor(player.transform.position.z / planeOffset) * planeOffset;

    private MapGroup mapGroup = new MapGroup();

    // Start is called before the first frame update
    void Start()
    {
        mapGroup.tileTable = new Dictionary<Vector3, GameObject>();
        //initialPooling();
        instantiateTiles();
    }

    // Update is called once per frame
    void Update()
    {
        // Check player position
        if (hasPlayerMoved())
        {
            // since player did move, then we reset the startPos to the nearest planeOffset 
            startPos.x = XPlayerLocation;
            startPos.z = ZPlayerLocation;
            instantiateTiles();
        }
    }

    bool hasPlayerMoved()
    {
        if (Mathf.Abs(XPlayerMove) >= planeOffset || Mathf.Abs(ZPlayerMove) >= planeOffset)
        {
            return true;
        }
        return false;
    }

    void initialPooling()
    {
        // create group of 3x3
        mapGroup.tileList = new List<GameObject>();
        // generate planes
        for (int i = 0; i < gridCount; i++)
        {
            GameObject tmp = Instantiate(plane);
            tmp.SetActive(false);
            // Add to tile list. Simply clone these variations with instantiate.
            mapGroup.tileList.Add(tmp);
        }
    }

    /*
     * instantiate logic should check if they exist in the current dictionary. If they do, then 
     * just retrieve them and setActive to true. Otherwise, instantiate and add.
     */
    void instantiateTiles()
    {
        int count = 0;
        // reposition the pooled map tiles using the tileSizes
        for (int z = mapRowRadius; z >= -mapRowRadius; z -= mapRowRadius)
        {
            for (int x = -mapColumnRadius; x <= mapColumnRadius; x += mapColumnRadius)
            {
                // pos shall be a function of tileSize * column + current player location
                Vector3 pos = new Vector3(
                    (tileSize * x + XPlayerLocation),                       // x 
                    0f,                                                     // y
                    (tileSize * z + ZPlayerLocation)                        // z
                    );

                if (!mapGroup.tileTable.ContainsKey(pos))
                {
                    GameObject tmp = Instantiate(plane, pos, Quaternion.identity);
                    tmp.SetActive(true);
                    mapGroup.tileTable[pos] = tmp;
                }
                else
                {
                    // retrieve from hashtable and setactive to true
                }
                
            }
        }
    }

    struct MapGroup
    {
        public Dictionary<Vector3, GameObject> tileTable;
        public List<GameObject> tileList;        

    }
}
