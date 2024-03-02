using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Randomly_Place_Items : MonoBehaviour
{

    [SerializeField] GameObject MudLayer;
    [SerializeField] GameObject ItemLayer;
    [SerializeField] GameObject BGLayer;
    System.Random rand = new System.Random();

    // Start is called before the first frame update
    void Start()
    {
        Tilemap mudtiles = MudLayer.GetComponent<Tilemap>();
        Tilemap itemtiles = ItemLayer.GetComponent<Tilemap>();
        Tilemap bgtiles = BGLayer.GetComponent<Tilemap>();

        TileBase[] mudtileArray = mudtiles.GetTilesBlock(bgtiles.cellBounds);
        TileBase[] itemtileArray = itemtiles.GetTilesBlock(bgtiles.cellBounds);
        TileBase[] bgtileArray = bgtiles.GetTilesBlock(bgtiles.cellBounds);

        int j = 0;
        for (int i = 0; i < bgtileArray.Length; i++)
        {
            if (bgtileArray[i] && bgtileArray[i].name == "Sand")
            {
                int chance = rand.Next(0, 50);

                if (chance == 0)
                {
                    Debug.Log("Placing object...");
                }
            }
        }
        Debug.Log(j);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
