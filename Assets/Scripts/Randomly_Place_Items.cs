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

        Tile mudtileAsset = Resources.Load<Tile>("mud");

        String[] itemNames = {"business_suit", "cheez", "coffee_pot", "cowboy_hat", "ducky",
            "fidget_spinner", "fish", "ice_cube", "literal_cat", "pinecone", "trumpet",
            "whoopie"};

        for (int i = 0; i < bgtileArray.Length; i++)
        {
            if (bgtileArray[i] && bgtileArray[i].name == "Sand")
            {
                int chance = rand.Next(0, 50);

                if (chance == 0)
                {
                    Tile randomItem = Resources.Load<Tile>(itemNames[rand.Next(0, 12)]);
                    itemtileArray[i] = randomItem;
                    mudtileArray[i] = null;
                }
            }
        }

        mudtiles.SetTilesBlock(bgtiles.cellBounds, mudtileArray);
        itemtiles.SetTilesBlock(bgtiles.cellBounds, itemtileArray);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
