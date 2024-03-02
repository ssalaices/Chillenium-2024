using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Randomly_Place_Items : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Tilemap tilemap = GetComponent<Tilemap>();
        TileBase[] tileArray = tilemap.GetTilesBlock(tilemap.cellBounds);
        Debug.Log("test");
        for (int index = 0; index < tileArray.Length; index++)
        {
            Debug.Log(tileArray[index]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
