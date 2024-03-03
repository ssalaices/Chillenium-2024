using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Randomly_Place_Items : MonoBehaviour
{

    [SerializeField] GameObject MudLayer;
    [SerializeField] GameObject BGLayer;
    System.Random rand = new System.Random();

    // Start is called before the first frame update
    void Start()
    {
        Tilemap mudtiles = MudLayer.GetComponent<Tilemap>();
        Tilemap bgtiles = BGLayer.GetComponent<Tilemap>();

        TileBase[] mudtileArray = mudtiles.GetTilesBlock(bgtiles.cellBounds);
        TileBase[] bgtileArray = bgtiles.GetTilesBlock(bgtiles.cellBounds);

        Tile mudtileAsset = Resources.Load<Tile>("mud");

        String[] itemNames = {"business_suit", "cheez", "coffee_pot", "cowboy_hat", "ducky",
            "fidget_spinner", "fish", "ice_cube", "literal_cat", "pinecone", "trumpet",
            "whoopie"};

        int x = (int) bgtiles.origin.x;
        int y = (int) bgtiles.origin.y;
        int min_x = x;
        int max_x = (int)bgtiles.cellBounds.max.x;

        for (int i = 0; i < bgtileArray.Length; i++)
        {
            if (bgtileArray[i] && bgtileArray[i].name == "Sand")
            {
                int chance = rand.Next(0, 50);

                if (chance == 0)
                {
                    int itemType = rand.Next(0, 12);
                    Sprite randomSprite = Resources.Load<Tile>(itemNames[itemType]).sprite;

                    GameObject randItem = new("item", typeof(BoxCollider2D), typeof(Rigidbody2D), 
                        typeof(SpriteRenderer), typeof(Item_Controller));

                    randItem.GetComponent<SpriteRenderer>().sprite = randomSprite;
                    randItem.GetComponent<SpriteRenderer>().sortingOrder = 1;
                    randItem.GetComponent<BoxCollider2D>().isTrigger = false;
                    randItem.GetComponent<Rigidbody2D>().gravityScale = 0;
                    randItem.GetComponent<Item_Controller>().type = itemType;
                    randItem.GetComponent<Transform>().position = new Vector3((float)x + 0.5f, (float)y + 0.5f, 0.0f);

                    mudtileArray[i] = mudtileAsset;
                }
            }

            x++;
            if (x == max_x)
            {
                x = min_x;
                y++;
            }
        }

        mudtiles.SetTilesBlock(bgtiles.cellBounds, mudtileArray);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
